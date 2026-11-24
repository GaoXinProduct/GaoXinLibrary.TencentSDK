using System.Net;
using System.Text;
using System.Text.Json;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wecom;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Extensions;
using GaoXinLibrary.TencentSDK.Wecom.Models.User;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace GaoXinLibrary.TencentSDK.Tests;

public sealed class WecomTransportTests
{
    [Theory]
    [InlineData(HttpStatusCode.BadRequest)]
    [InlineData(HttpStatusCode.Unauthorized)]
    [InlineData(HttpStatusCode.Forbidden)]
    [InlineData(HttpStatusCode.NotFound)]
    public async Task ReadDoesNotRetryPermanentHttpErrors(HttpStatusCode statusCode)
    {
        var requests = 0;
        var content = new StallingContent();
        using var handler = new ScriptedHandler((_, _) =>
        {
            requests++;
            return Task.FromResult(new HttpResponseMessage(statusCode) { Content = content });
        });
        using var httpClient = new HttpClient(handler) { Timeout = TimeSpan.FromSeconds(1) };
        using var client = CreateClient(httpClient);

        var error = await Assert.ThrowsAsync<HttpRequestException>(() => client.User.GetUserAsync("employee"));

        Assert.Equal(statusCode, error.StatusCode);
        Assert.Equal(1, requests);
        Assert.True(content.Disposed);
    }

    [Theory]
    [InlineData(HttpStatusCode.RequestTimeout)]
    [InlineData(HttpStatusCode.TooManyRequests)]
    [InlineData(HttpStatusCode.ServiceUnavailable)]
    public async Task ReadRetriesTransientHttpErrorsAndDisposesResponses(HttpStatusCode statusCode)
    {
        var first = new TrackingContent("{}");
        var second = new TrackingContent("""{"errcode":0,"userid":"employee"}""");
        var requests = 0;
        using var handler = new ScriptedHandler((_, _) => Task.FromResult(++requests == 1
            ? new HttpResponseMessage(statusCode) { Content = first }
            : new HttpResponseMessage(HttpStatusCode.OK) { Content = second }));
        using var httpClient = new HttpClient(handler);
        using var client = CreateClient(httpClient);

        Assert.Equal("employee", (await client.User.GetUserAsync("employee")).UserId);
        Assert.Equal(2, requests);
        Assert.True(first.Disposed);
        Assert.True(second.Disposed);
    }

    [Theory]
    [InlineData("/cgi-bin/message/send")]
    [InlineData("/cgi-bin/auth/getuserinfo")]
    [InlineData("/cgi-bin/user/delete")]
    public async Task WritesAndOneTimeCodesDoNotReplayOnTimeout(string path)
    {
        var requests = 0;
        using var handler = new ScriptedHandler((request, _) =>
        {
            Assert.Equal(path, request.RequestUri!.AbsolutePath);
            requests++;
            throw new TaskCanceledException("request timed out");
        });
        using var httpClient = new HttpClient(handler);
        using var client = CreateClient(httpClient);

        Func<Task> call = path switch
        {
            "/cgi-bin/message/send" => () => client.Message.SendTextAsync("hello", toUser: "employee"),
            "/cgi-bin/auth/getuserinfo" => () => client.OAuth.GetUserInfoAsync("one-time-code"),
            _ => () => client.User.DeleteUserAsync("employee")
        };
        await Assert.ThrowsAnyAsync<OperationCanceledException>(call);

        Assert.Equal(1, requests);
    }

    [Fact]
    public async Task TokenRejectionRefreshesAndReplaysTheWriteOnce()
    {
        var paths = new List<string>();
        var first = new TrackingContent("""{"errcode":"40014","errmsg":"invalid token"}""");
        var second = new TrackingContent("""{"errcode":0}""");
        var tokenReplies = 0;
        using var handler = new ScriptedHandler(async (request, ct) =>
        {
            paths.Add(request.RequestUri!.AbsolutePath);
            if (request.RequestUri.AbsolutePath == "/cgi-bin/gettoken")
            {
                tokenReplies++;
                return await Reply("""{"errcode":0,"access_token":"fresh","expires_in":7200}""");
            }

            using var body = JsonDocument.Parse(await request.Content!.ReadAsStringAsync(ct));
            Assert.Equal(7, body.RootElement.GetProperty("agentid").GetInt32());
            Assert.Equal(tokenReplies == 0 ? "?access_token=cached" : "?access_token=fresh", request.RequestUri.Query);
            return new HttpResponseMessage(HttpStatusCode.OK) { Content = tokenReplies == 0 ? first : second };
        });
        using var httpClient = new HttpClient(handler);
        using var client = CreateClient(httpClient);

        await client.Message.SendTextAsync("hello", toUser: "employee");

        Assert.Equal(new[] { "/cgi-bin/message/send", "/cgi-bin/gettoken", "/cgi-bin/message/send" }, paths);
        Assert.True(first.Disposed);
        Assert.True(second.Disposed);
    }

    [Fact]
    public async Task OldTokenFailuresOnlyRefreshOnceWhenTokenValueIsUnchanged()
    {
        using var deadline = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var bothStarted = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var firstRetried = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var requests = 0;
        var refreshes = 0;
        using var handler = new ScriptedHandler(async (request, ct) =>
        {
            if (request.RequestUri!.AbsolutePath == "/cgi-bin/gettoken")
            {
                Interlocked.Increment(ref refreshes);
                return await Reply("""{"errcode":0,"access_token":"cached","expires_in":7200}""");
            }

            switch (Interlocked.Increment(ref requests))
            {
                case 1:
                    await bothStarted.Task.WaitAsync(ct);
                    return await Reply("""{"errcode":42001,"errmsg":"expired"}""");
                case 2:
                    bothStarted.SetResult();
                    await firstRetried.Task.WaitAsync(ct);
                    return await Reply("""{"errcode":42001,"errmsg":"expired"}""");
                case 3:
                    firstRetried.SetResult();
                    break;
            }

            return await Reply("""{"errcode":0,"userid":"employee"}""");
        });
        using var httpClient = new HttpClient(handler);
        using var client = CreateClient(httpClient);

        var first = client.User.GetUserAsync("employee", deadline.Token);
        var second = client.User.GetUserAsync("employee", deadline.Token);
        await Task.WhenAll(first, second);

        Assert.Equal(1, refreshes);
        Assert.Equal(4, requests);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task ExplicitTokenUpdateWinsOverAnInFlightRefresh(bool whileNotifying)
    {
        using var deadline = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var started = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var release = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        async Task WaitForExplicitUpdateAsync(CancellationToken ct)
        {
            started.SetResult();
            await release.Task.WaitAsync(ct);
        }

        using var handler = new ScriptedHandler(async (_, ct) =>
        {
            if (!whileNotifying)
                await WaitForExplicitUpdateAsync(ct);
            return await Reply("""{"errcode":0,"access_token":"in-flight","expires_in":7200}""");
        });
        using var httpClient = new HttpClient(handler);
        var tokens = new AccessTokenProvider(Options(), httpClient);
        if (whileNotifying)
            tokens.OnTokenChanged = (_, ct) => WaitForExplicitUpdateAsync(ct);

        var fromServer = tokens.GetTokenAsync(deadline.Token);
        await started.Task.WaitAsync(deadline.Token);
        tokens.SetToken("explicit");
        release.SetResult();

        Assert.Equal("explicit", await fromServer);
        Assert.Equal("explicit", await tokens.GetTokenAsync(deadline.Token));
    }

    [Fact]
    public async Task InvalidWecomSecretDoesNotRefreshAndLogsOnlyErrorCode()
    {
        var paths = new List<string>();
        var logger = new TestLogger<WecomClient>();
        using var handler = new ScriptedHandler((request, _) =>
        {
            paths.Add(request.RequestUri!.AbsolutePath);
            return Reply("""{"errcode":40001,"errmsg":"bad secret: secret-value"}""");
        });
        using var httpClient = new HttpClient(handler);
        using var client = CreateClient(httpClient, logger);

        var error = await Assert.ThrowsAsync<TencentException>(() => client.User.GetUserAsync("employee"));

        Assert.Equal(40001, error.ErrCode);
        Assert.Equal(new[] { "/cgi-bin/user/get" }, paths);
        Assert.Contains(logger.Entries, entry => entry.Message.Contains("40001", StringComparison.Ordinal));
        Assert.DoesNotContain(logger.Entries, entry => entry.Message.Contains("secret-value", StringComparison.Ordinal));
    }

    [Fact]
    public async Task InvalidErrorCodeIsNotTreatedAsSuccess()
    {
        using var handler = new ScriptedHandler((_, _) => Reply("""{"errcode":"bad","userid":"employee"}"""));
        using var httpClient = new HttpClient(handler);
        using var client = CreateClient(httpClient);

        await Assert.ThrowsAsync<JsonException>(() => client.User.GetUserAsync("employee"));
    }

    [Fact]
    public async Task StreamingBodyObservesHttpTimeoutWithoutReplayingPartialWrites()
    {
        var requests = 0;
        var content = new StallingContent();
        using var handler = new ScriptedHandler((request, _) =>
        {
            requests++;
            Assert.Equal(HttpVersion.Version20, request.Version);
            Assert.Equal(HttpVersionPolicy.RequestVersionExact, request.VersionPolicy);
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = content });
        });
        using var httpClient = new HttpClient(handler)
        {
            Timeout = TimeSpan.FromSeconds(1),
            DefaultRequestVersion = HttpVersion.Version20,
            DefaultVersionPolicy = HttpVersionPolicy.RequestVersionExact
        };
        using var client = CreateClient(httpClient);
        using var destination = new MemoryStream();

        await Assert.ThrowsAnyAsync<OperationCanceledException>(() => client.Media.DownloadTempMediaAsync("media", destination)
            .WaitAsync(TimeSpan.FromSeconds(5)));

        Assert.Equal(1, requests);
        Assert.Equal(new byte[] { 1 }, destination.ToArray());
        Assert.True(content.Disposed);
    }

    [Fact]
    public async Task BufferedBinaryReadsRespectConfiguredBufferSize()
    {
        using var handler = new ScriptedHandler((_, _) => Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new ByteArrayContent(new byte[5])
        }));
        using var httpClient = new HttpClient(handler) { MaxResponseContentBufferSize = 4 };
        var options = Options();
        var tokenProvider = new AccessTokenProvider(options, httpClient);
        tokenProvider.SetToken("cached");
        var transport = new WecomHttpClient(httpClient, tokenProvider, options);

        await Assert.ThrowsAsync<HttpRequestException>(() => transport.GetForBytesAsync("/bytes"));
    }

    [Fact]
    public async Task InviteMemberUsesTheBatchInviteContract()
    {
        using var handler = new ScriptedHandler(async (request, ct) =>
        {
            Assert.Equal(HttpMethod.Post, request.Method);
            Assert.Equal("/cgi-bin/batch/invite", request.RequestUri!.AbsolutePath);
            using var body = JsonDocument.Parse(await request.Content!.ReadAsStringAsync(ct));
            Assert.Equal("employee", body.RootElement.GetProperty("user")[0].GetString());
            return await Reply("""{"errcode":0,"invaliduser":["employee"]}""");
        });
        using var httpClient = new HttpClient(handler);
        using var client = CreateClient(httpClient);

        var response = await client.User.InviteMemberAsync(new InviteMemberRequest { User = ["employee"] });

        Assert.Equal("employee", Assert.Single(response.InvalidUser!));
    }

    [Fact]
    public void NewServicesAreAvailableFromRegularAndKeyedWecomClients()
    {
        using var provider = new ServiceCollection()
            .AddWecomService(Options())
            .AddWecomService("named", Options())
            .BuildServiceProvider();

        var regular = provider.GetRequiredService<WecomClient>();
        var named = provider.GetRequiredKeyedService<WecomClient>("named");

        Assert.NotNull(regular.Todo);
        Assert.NotNull(regular.ContactRule);
        Assert.NotNull(regular.SmartDocument);
        Assert.NotSame(regular.Todo, named.Todo);
        Assert.NotSame(regular.ContactRule, named.ContactRule);
        Assert.NotSame(regular.SmartDocument, named.SmartDocument);
    }

    private static WecomOptions Options() => new()
    {
        CorpId = "company",
        CorpSecret = "secret-value",
        BaseUrl = "https://example.test",
        AgentId = 7,
        RetryOptions = new TencentRetryOptions { MaxRetries = 2, InitialDelay = TimeSpan.Zero }
    };

    private static WecomClient CreateClient(HttpClient httpClient, TestLogger<WecomClient>? logger = null)
    {
        var client = WecomClient.Create(Options(), httpClient, logger);
        client.SetAccessToken("cached");
        return client;
    }

    private static Task<HttpResponseMessage> Reply(string json, HttpStatusCode statusCode = HttpStatusCode.OK)
        => Task.FromResult(new HttpResponseMessage(statusCode)
        {
            Content = new StringContent(json, Encoding.UTF8, "application/json")
        });

    private sealed class ScriptedHandler(Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> send) : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken ct) => send(request, ct);
    }

    private sealed class TrackingContent(string json) : StringContent(json, Encoding.UTF8, "application/json")
    {
        public bool Disposed { get; private set; }

        protected override void Dispose(bool disposing)
        {
            Disposed = true;
            base.Dispose(disposing);
        }
    }

    private sealed class StallingContent : HttpContent
    {
        public bool Disposed { get; private set; }

        protected override Task SerializeToStreamAsync(Stream stream, TransportContext? context)
            => throw new InvalidOperationException("HTTP timeout cancellation token is required.");

        protected override async Task SerializeToStreamAsync(Stream stream, TransportContext? context, CancellationToken cancellationToken)
        {
            await stream.WriteAsync(new byte[] { 1 }, cancellationToken);
            await Task.Delay(Timeout.InfiniteTimeSpan, cancellationToken);
        }

        protected override bool TryComputeLength(out long length)
        {
            length = 0;
            return false;
        }

        protected override void Dispose(bool disposing)
        {
            Disposed = true;
            base.Dispose(disposing);
        }
    }
}

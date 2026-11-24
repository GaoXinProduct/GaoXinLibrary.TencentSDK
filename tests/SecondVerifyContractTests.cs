using System.Net;
using System.Text.Json.Nodes;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wecom;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.SecondVerify;
using Xunit;

namespace GaoXinLibrary.TencentSDK.Tests;

public sealed class SecondVerifyContractTests
{
    [Fact]
    public async Task UseVerification_ExchangesAndSubmitsTheDocumentedCodes()
    {
        var handler = new VerificationHandler(
            new(HttpMethod.Post, "/cgi-bin/auth/get_tfa_info", """{"code":"example-authorization"}""",
                """{"errcode":0,"userid":"member","tfa_code":"example-confirmation"}"""),
            new(HttpMethod.Post, "/cgi-bin/user/tfa_succ", """{"userid":"member","tfa_code":"example-confirmation"}""",
                """{"errcode":0}"""));
        using var http = new HttpClient(handler);
        using var client = CreateClient(http);

        var info = await client.SecondVerify.GetTfaInfoAsync(new GetTfaInfoRequest { Code = "example-authorization" });
        Assert.Equal("member", info.UserId);
        Assert.Equal("example-confirmation", info.TfaCode);
        await client.SecondVerify.CompleteTfaAsync(new CompleteTfaRequest { UserId = info.UserId!, TfaCode = info.TfaCode! });

        Assert.Equal(2, handler.RequestCount);
    }

    [Theory]
    [InlineData("/cgi-bin/auth/get_tfa_info", """{"code":"example-authorization"}""")]
    [InlineData("/cgi-bin/user/tfa_succ", """{"userid":"member","tfa_code":"example-confirmation"}""")]
    [InlineData("/cgi-bin/user/authsucc?userid=member", null)]
    public async Task VerificationOperations_DoNotReplayAfterTransientFailures(string path, string? json)
    {
        var handler = new VerificationHandler(new ExpectedCall(json is null ? HttpMethod.Get : HttpMethod.Post,
            path, json, "{}", HttpStatusCode.ServiceUnavailable));
        using var http = new HttpClient(handler);
        using var client = CreateClient(http);

        var error = await Assert.ThrowsAsync<HttpRequestException>(() => path switch
        {
            "/cgi-bin/auth/get_tfa_info" => client.SecondVerify.GetTfaInfoAsync(new GetTfaInfoRequest { Code = "example-authorization" }),
            "/cgi-bin/user/tfa_succ" => client.SecondVerify.CompleteTfaAsync(new CompleteTfaRequest { UserId = "member", TfaCode = "example-confirmation" }),
            _ => client.SecondVerify.CompleteFirstLoginAsync("member")
        });

        Assert.Equal(HttpStatusCode.ServiceUnavailable, error.StatusCode);
        Assert.Equal(1, handler.RequestCount);
    }

    private static WecomClient CreateClient(HttpClient http)
    {
        var client = WecomClient.Create(new WecomOptions
        {
            CorpId = "example",
            CorpSecret = "unused",
            BaseUrl = "https://example.test",
            RetryOptions = new TencentRetryOptions { MaxRetries = 2, InitialDelay = TimeSpan.Zero, MaxDelay = TimeSpan.Zero }
        }, http);
        client.SetAccessToken("test-token");
        return client;
    }

    private sealed record ExpectedCall(HttpMethod Method, string Path, string? Json, string Response,
        HttpStatusCode Status = HttpStatusCode.OK);

    private sealed class VerificationHandler(params ExpectedCall[] expected) : HttpMessageHandler
    {
        public int RequestCount { get; private set; }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Assert.True(RequestCount < expected.Length, "An unexpected verification request was sent.");
            var call = expected[RequestCount++];
            Assert.Equal(call.Method, request.Method);
            var requestUri = request.RequestUri!;
            var query = requestUri.Query.TrimStart('?').Split('&');
            Assert.Contains("access_token=test-token", query);
            var otherQuery = string.Join('&', query.Where(value => value != "access_token=test-token"));
            Assert.Equal(call.Path, otherQuery.Length == 0 ? requestUri.AbsolutePath : requestUri.AbsolutePath + "?" + otherQuery);
            if (call.Json is null)
            {
                Assert.Null(request.Content);
            }
            else
            {
                Assert.NotNull(request.Content);
                var json = await request.Content.ReadAsStringAsync(cancellationToken);
                Assert.True(JsonNode.DeepEquals(JsonNode.Parse(call.Json), JsonNode.Parse(json)));
            }
            return new HttpResponseMessage(call.Status) { Content = new StringContent(call.Response) };
        }
    }
}

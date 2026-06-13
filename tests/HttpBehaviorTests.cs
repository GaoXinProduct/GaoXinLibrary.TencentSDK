using System.Net;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using Xunit;

namespace GaoXinLibrary.TencentSDK.Tests;

public sealed class HttpBehaviorTests
{
    [Fact]
    public async Task GetAsync_RetriesTransientFailureAndReusesCachedToken()
    {
        var handler = new ScriptedHandler(
            request => request.RequestUri!.AbsolutePath == "/cgi-bin/token"
                ? new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("{\"errcode\":0,\"access_token\":\"token-1\",\"expires_in\":7200}") }
                : throw new HttpRequestException("transient"),
            request => new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("{\"errcode\":0,\"errmsg\":\"ok\"}") },
            request => new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("{\"errcode\":0,\"errmsg\":\"ok\"}") });

        var options = new WechatOptions
        {
            AppId = "app",
            AppSecret = "secret",
            BaseUrl = "https://example.test",
            RetryOptions = new TencentRetryOptions { MaxRetries = 1, InitialDelay = TimeSpan.Zero, MaxDelay = TimeSpan.Zero }
        };
        var httpClient = new HttpClient(handler);
        var tokenProvider = new AccessTokenProvider(options, httpClient);
        var client = new WechatHttpClient(httpClient, tokenProvider, options);

        await client.GetAsync<WechatBaseResponse>("/cgi-bin/anything");
        await client.GetAsync<WechatBaseResponse>("/cgi-bin/anything");

        Assert.Equal(3, handler.Requests.Count);
        Assert.Single(handler.Requests, request => request.RequestUri!.AbsolutePath == "/cgi-bin/token");
        Assert.All(handler.Requests.Where(request => request.RequestUri!.AbsolutePath != "/cgi-bin/token"), request =>
            Assert.Contains("access_token=token-1", request.RequestUri!.Query));
    }

    private sealed class ScriptedHandler(params Func<HttpRequestMessage, HttpResponseMessage>[] responses) : HttpMessageHandler
    {
        private int _index;

        public List<HttpRequestMessage> Requests { get; } = [];

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Requests.Add(request);
            var response = responses[_index++](request);
            return Task.FromResult(response);
        }
    }
}

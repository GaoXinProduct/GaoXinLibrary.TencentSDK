using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Services;
using Microsoft.Extensions.Logging;
using Xunit;

namespace GaoXinLibrary.TencentSDK.Tests;

public sealed class CallbackDiagnosticsTests
{
    [Fact]
    public void OfficialCallbackParseMessage_WhenXmlIsInvalid_LogsAndThrows()
    {
        var logger = new TestLogger<OfficialCallbackService>();
        var service = new OfficialCallbackService(CreateHttpClient(), new WechatOfficialOptions
        {
            AppId = "app",
            AppSecret = "secret",
            CallbackToken = "token"
        }, logger);

        Assert.ThrowsAny<Exception>(() => service.ParseMessage("<xml>"));
        Assert.Contains(logger.Entries, entry =>
            entry.Level == LogLevel.Warning &&
            entry.Message.Contains("回调", StringComparison.Ordinal) &&
            entry.Exception is not null);
    }

    [Fact]
    public void OfficialCallbackVerifyUrl_WhenSignatureIsInvalid_LogsAndThrows()
    {
        var logger = new TestLogger<OfficialCallbackService>();
        var service = new OfficialCallbackService(CreateHttpClient(), new WechatOfficialOptions
        {
            AppId = "app",
            AppSecret = "secret",
            CallbackToken = "token"
        }, logger);

        Assert.Throws<TencentException>(() => service.VerifyUrl("bad", "1", "nonce", "echo"));
        Assert.Contains(logger.Entries, entry =>
            entry.Level == LogLevel.Warning &&
            entry.Message.Contains("回调", StringComparison.Ordinal) &&
            entry.Exception is not null);
    }

    private static WechatHttpClient CreateHttpClient()
    {
        var options = new WechatOptions { AppId = "app", AppSecret = "secret" };
        var httpClient = new HttpClient(new EmptyHandler());
        return new WechatHttpClient(httpClient, new AccessTokenProvider(options, httpClient), options);
    }

    private sealed class EmptyHandler : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            => Task.FromResult(new HttpResponseMessage(System.Net.HttpStatusCode.OK));
    }
}

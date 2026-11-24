using System.Net;
using System.Text.Json;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.SmartRobot;
using GaoXinLibrary.TencentSDK.Wecom.Services;
using Xunit;

namespace GaoXinLibrary.TencentSDK.Tests;

public sealed class SmartRobotContractTests
{
    private const string CallbackToken = "test-token";
    private const string ReplyUrl = "https://qyapi.weixin.qq.com/cgi-bin/aibot/response?response_code=one-time-code";

    [Fact]
    public async Task ReplyAsync_PostsToCallbackUrlWithOnlyReplyCredential()
    {
        using var appHandler = new ReplyHandler(HttpStatusCode.InternalServerError);
        using var appHttp = new HttpClient(appHandler);
        using var replyHandler = new ReplyHandler(HttpStatusCode.OK);
        using var replyHttp = new HttpClient(replyHandler);
        var service = CreateService(appHttp, replyHttp);
        await service.ReplyAsync(ReplyUrl, MarkdownReply());

        Assert.Equal(1, replyHandler.RequestCount);
        Assert.Equal(0, appHandler.RequestCount);
        Assert.Equal(new Uri(ReplyUrl), replyHandler.Uri);
        Assert.Equal(HttpMethod.Post, replyHandler.Method);
        Assert.Equal("application/json", replyHandler.ContentType);
        Assert.False(replyHandler.SentAuthorization);
        using var body = JsonDocument.Parse(replyHandler.Body!);
        Assert.Equal("markdown", body.RootElement.GetProperty("msgtype").GetString());
        Assert.Equal("你好", body.RootElement.GetProperty("markdown").GetProperty("content").GetString());
        Assert.False(body.RootElement.TryGetProperty("template_card", out _));
    }

    [Fact]
    public async Task ReplyAsync_UsesTemplateCardBodyAndPreservesServiceErrorCode()
    {
        using var handler = new ReplyHandler(HttpStatusCode.OK, """{"errcode":45009,"errmsg":"reply failed"}""");
        using var http = new HttpClient(handler);
        var service = CreateService(http, http);
        using var card = JsonDocument.Parse("""{"card_type":"text_notice","main_title":{"title":"通知"}}""");
        var reply = new SmartRobotReplyRequest { MsgType = "template_card", TemplateCard = card.RootElement };

        var error = await Assert.ThrowsAsync<TencentException>(() => service.ReplyAsync(ReplyUrl, reply));

        Assert.Equal(45009, error.ErrCode);
        Assert.Equal(1, handler.RequestCount);
        using var body = JsonDocument.Parse(handler.Body!);
        Assert.Equal("text_notice", body.RootElement.GetProperty("template_card").GetProperty("card_type").GetString());
        Assert.False(body.RootElement.TryGetProperty("markdown", out _));
    }

    [Theory]
    [InlineData(HttpStatusCode.ServiceUnavailable)]
    [InlineData(HttpStatusCode.TemporaryRedirect)]
    public async Task ReplyAsync_ReportsUnsuccessfulResponseAfterOneRequest(HttpStatusCode status)
    {
        using var handler = new ReplyHandler(status);
        using var http = new HttpClient(handler);
        var service = CreateService(http, http);

        var error = await Assert.ThrowsAsync<HttpRequestException>(() => service.ReplyAsync(ReplyUrl, MarkdownReply()));

        Assert.Equal(status, error.StatusCode);
        Assert.Equal(1, handler.RequestCount);
        Assert.DoesNotContain("one-time-code", error.Message, StringComparison.Ordinal);
    }

    [Theory]
    [InlineData("http://qyapi.weixin.qq.com/cgi-bin/aibot/response?response_code=code")]
    [InlineData("https://qyapi.weixin.qq.com.example.test/cgi-bin/aibot/response?response_code=code")]
    [InlineData("https://qyapi.weixin.qq.com/cgi-bin/message/send?response_code=code")]
    [InlineData("https://qyapi.weixin.qq.com/cgi-bin/aibot/response?response_code=code&access_token=token")]
    [InlineData("https://qyapi.weixin.qq.com/cgi-bin/aibot/response?response_code=")]
    public async Task ReplyAsync_RejectsNonCallbackUrls(string url)
    {
        using var handler = new ReplyHandler(HttpStatusCode.OK);
        using var http = new HttpClient(handler);
        var service = CreateService(http, http);

        await Assert.ThrowsAsync<ArgumentException>(() => service.ReplyAsync(url, MarkdownReply()));

        Assert.Equal(0, handler.RequestCount);
    }

    [Fact]
    public void DecryptApiCallback_VerifiesEmptyRecipientAndPreservesResponseUrl()
    {
        using var http = new HttpClient(new ReplyHandler(HttpStatusCode.OK));
        var options = CreateOptions();
        var service = CreateService(http, http, options);
        var apiCrypto = WecomCryptoHelper.CreateForSmartRobot(CallbackToken, options.CallbackEncodingAesKey!);
        const string timestamp = "1750000000";
        const string nonce = "nonce";
        var payload = JsonSerializer.Serialize(new
        {
            msgid = "message",
            aibotid = "bot",
            msgtype = "text",
            response_url = ReplyUrl,
            text = new { content = "你好" }
        });
        var cipher = apiCrypto.Encrypt(payload);
        var signature = apiCrypto.ComputeSignature(timestamp, nonce, cipher);

        var callback = service.DecryptApiCallback(signature, timestamp, nonce, JsonSerializer.Serialize(new { encrypt = cipher }));
        Assert.Equal("bot", callback.BotId);
        Assert.Equal("message", callback.MsgId);
        Assert.Equal(ReplyUrl, callback.ResponseUrl);
        Assert.Equal("你好", callback.Payload!["text"].GetProperty("content").GetString());
        Assert.Throws<TencentException>(() =>
            service.DecryptApiCallback("incorrect", timestamp, nonce, JsonSerializer.Serialize(new { encrypt = cipher })));

        var echo = apiCrypto.Encrypt("hello");
        Assert.Equal("hello", service.VerifyApiCallbackUrl(apiCrypto.ComputeSignature(timestamp, nonce, echo), timestamp, nonce, echo));
        Assert.Throws<TencentException>(() =>
            service.VerifyUrl(apiCrypto.ComputeSignature(timestamp, nonce, echo), timestamp, nonce, echo));
        Assert.Throws<ArgumentException>(() => new WecomCryptoHelper(CallbackToken, options.CallbackEncodingAesKey!, ""));
    }

    private static SmartRobotReplyRequest MarkdownReply()
        => new() { Markdown = new SmartRobotMarkdownReply { Content = "你好" } };

    private static SmartRobotService CreateService(HttpClient appHttp, HttpClient replyHttp, WecomOptions? options = null)
    {
        options ??= CreateOptions();
        return new SmartRobotService(new WecomHttpClient(appHttp, new AccessTokenProvider(options, appHttp), options), options, replyHttp);
    }

    private static WecomOptions CreateOptions() => new()
    {
        CorpId = "corp",
        CorpSecret = "secret",
        CallbackToken = CallbackToken,
        CallbackEncodingAesKey = Convert.ToBase64String(new byte[32]).TrimEnd('=')
    };

    private sealed class ReplyHandler(HttpStatusCode status, string responseBody = """{"errcode":0,"errmsg":"ok"}""") : HttpMessageHandler
    {
        public int RequestCount { get; private set; }
        public Uri? Uri { get; private set; }
        public HttpMethod? Method { get; private set; }
        public string? Body { get; private set; }
        public string? ContentType { get; private set; }
        public bool SentAuthorization { get; private set; }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            RequestCount++;
            Uri = request.RequestUri;
            Method = request.Method;
            Body = await request.Content!.ReadAsStringAsync(cancellationToken);
            ContentType = request.Content.Headers.ContentType?.MediaType;
            SentAuthorization = request.Headers.Authorization is not null;
            var response = new HttpResponseMessage(status) { Content = new StringContent(responseBody) };
            if (status == HttpStatusCode.TemporaryRedirect)
                response.Headers.Location = new Uri("https://example.test");
            return response;
        }
    }
}

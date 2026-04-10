using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Webhook;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>
/// 群机器人（Webhook）消息推送服务实现
/// </summary>
public class WebhookService : IWebhookService
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
    };

    private readonly HttpClient _http;
    private readonly string _sendUrl;

    /// <summary>
    /// 初始化群机器人服务
    /// </summary>
    /// <param name="http">HTTP 客户端</param>
    /// <param name="baseUrl">API 基础地址</param>
    /// <param name="webhookKey">群机器人 Webhook Key（来自机器人配置页面）</param>
    public WebhookService(HttpClient http, string baseUrl, string webhookKey)
    {
        _http = http;
        _sendUrl = $"{baseUrl.TrimEnd('/')}/cgi-bin/webhook/send?key={webhookKey}";
    }

    /// <inheritdoc/>
    public async Task SendAsync(WebhookMessageRequest request, CancellationToken ct = default)
    {
        var bytes = JsonSerializer.SerializeToUtf8Bytes(request, JsonOptions);
        var content = new ByteArrayContent(bytes);
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json") { CharSet = "utf-8" };

        var response = await _http.PostAsync(_sendUrl, content, ct);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync(ct);
        var result = JsonSerializer.Deserialize<WecomBaseResponse>(json, JsonOptions)
                     ?? throw new TencentException("群机器人响应反序列化失败");

        if (result.ErrCode != 0)
            throw new TencentException(result.ErrCode, result.ErrMsg ?? "未知错误", "企业微信");
    }

    /// <inheritdoc/>
    public Task SendTextAsync(string content, string[]? mentionedList = null, string[]? mentionedMobileList = null, CancellationToken ct = default)
        => SendAsync(new WebhookMessageRequest
        {
            MsgType = "text",
            Text = new WebhookTextContent
            {
                Content = content,
                MentionedList = mentionedList,
                MentionedMobileList = mentionedMobileList
            }
        }, ct);

    /// <inheritdoc/>
    public Task SendMarkdownAsync(string content, CancellationToken ct = default)
        => SendAsync(new WebhookMessageRequest
        {
            MsgType = "markdown",
            Markdown = new WebhookMarkdownContent { Content = content }
        }, ct);

    /// <inheritdoc/>
    public Task SendNewsAsync(WebhookNewsArticle[] articles, CancellationToken ct = default)
        => SendAsync(new WebhookMessageRequest
        {
            MsgType = "news",
            News = new WebhookNewsContent { Articles = articles }
        }, ct);

    /// <inheritdoc/>
    public Task SendImageAsync(string base64, string md5, CancellationToken ct = default)
        => SendAsync(new WebhookMessageRequest
        {
            MsgType = "image",
            Image = new WebhookImageContent { Base64 = base64, Md5 = md5 }
        }, ct);

    /// <inheritdoc/>
    public Task SendFileAsync(string mediaId, CancellationToken ct = default)
        => SendAsync(new WebhookMessageRequest
        {
            MsgType = "file",
            File = new WebhookFileContent { MediaId = mediaId }
        }, ct);
}

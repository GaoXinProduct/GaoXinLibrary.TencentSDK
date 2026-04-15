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
public class WebhookService
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

    /// <summary>
    /// 发送任意类型的 Webhook 消息
    /// <para>对应接口：POST /cgi-bin/webhook/send?key={webhookKey}</para>
    /// </summary>
    /// <param name="request">消息体，需设置 MsgType 及对应内容字段</param>
    /// <param name="ct">取消令牌</param>
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

    /// <summary>
    /// 发送文本消息，支持 @指定成员
    /// </summary>
    /// <param name="content">消息内容，最长不超过2048字节</param>
    /// <param name="mentionedList">需要 @的成员 UserId 列表；使用 <c>"@all"</c> 可 @所有人</param>
    /// <param name="mentionedMobileList">需要 @的成员手机号列表；使用 <c>"@all"</c> 可 @所有人</param>
    /// <param name="ct">取消令牌</param>
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

    /// <summary>
    /// 发送 Markdown 消息（支持企业微信 Markdown 语法）
    /// </summary>
    /// <param name="content">Markdown 内容，最长不超过4096字节</param>
    /// <param name="ct">取消令牌</param>
    public Task SendMarkdownAsync(string content, CancellationToken ct = default)
        => SendAsync(new WebhookMessageRequest
        {
            MsgType = "markdown",
            Markdown = new WebhookMarkdownContent { Content = content }
        }, ct);

    /// <summary>
    /// 发送图文消息（图文链接卡片列表）
    /// </summary>
    /// <param name="articles">图文卡片数组，最多8条</param>
    /// <param name="ct">取消令牌</param>
    public Task SendNewsAsync(WebhookNewsArticle[] articles, CancellationToken ct = default)
        => SendAsync(new WebhookMessageRequest
        {
            MsgType = "news",
            News = new WebhookNewsContent { Articles = articles }
        }, ct);

    /// <summary>
    /// 发送图片消息（Base64 编码）
    /// </summary>
    /// <param name="base64">图片 Base64 编码内容，不超过2MB</param>
    /// <param name="md5">图片内容的 MD5 值，用于校验</param>
    /// <param name="ct">取消令牌</param>
    public Task SendImageAsync(string base64, string md5, CancellationToken ct = default)
        => SendAsync(new WebhookMessageRequest
        {
            MsgType = "image",
            Image = new WebhookImageContent { Base64 = base64, Md5 = md5 }
        }, ct);

    /// <summary>
    /// 发送文件消息（通过 media_id 引用已上传的素材）
    /// </summary>
    /// <param name="mediaId">通过素材上传接口获取的 media_id</param>
    /// <param name="ct">取消令牌</param>
    public Task SendFileAsync(string mediaId, CancellationToken ct = default)
        => SendAsync(new WebhookMessageRequest
        {
            MsgType = "file",
            File = new WebhookFileContent { MediaId = mediaId }
        }, ct);
}

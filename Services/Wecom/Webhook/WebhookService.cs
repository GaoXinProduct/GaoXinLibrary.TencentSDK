using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Webhook;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

public class WebhookService : IWebhookService
{
    private readonly WecomHttpClient _http;
    private readonly string _baseUrl;

    public WebhookService(WecomHttpClient http, string baseUrl)
    {
        _http = http;
        _baseUrl = baseUrl.TrimEnd('/');
    }

    public async Task SendAsync(string webhookKey, WebhookMessageRequest request, CancellationToken ct = default)
        => await _http.PostWithoutTokenAsync<WecomBaseResponse>(
            $"{_baseUrl}/cgi-bin/webhook/send?key={webhookKey}", request, ct);

    public Task SendTextAsync(string webhookKey, string content, string[]? mentionedList = null, string[]? mentionedMobileList = null, CancellationToken ct = default)
        => SendAsync(webhookKey, new WebhookMessageRequest
        {
            MsgType = "text",
            Text = new WebhookTextContent
            {
                Content = content,
                MentionedList = mentionedList,
                MentionedMobileList = mentionedMobileList
            }
        }, ct);

    public Task SendMarkdownAsync(string webhookKey, string content, CancellationToken ct = default)
        => SendAsync(webhookKey, new WebhookMessageRequest
        {
            MsgType = "markdown",
            Markdown = new WebhookMarkdownContent { Content = content }
        }, ct);

    public Task SendNewsAsync(string webhookKey, WebhookNewsArticle[] articles, CancellationToken ct = default)
        => SendAsync(webhookKey, new WebhookMessageRequest
        {
            MsgType = "news",
            News = new WebhookNewsContent { Articles = articles }
        }, ct);

    public Task SendImageAsync(string webhookKey, string base64, string md5, CancellationToken ct = default)
        => SendAsync(webhookKey, new WebhookMessageRequest
        {
            MsgType = "image",
            Image = new WebhookImageContent { Base64 = base64, Md5 = md5 }
        }, ct);

    public Task SendFileAsync(string webhookKey, string mediaId, CancellationToken ct = default)
        => SendAsync(webhookKey, new WebhookMessageRequest
        {
            MsgType = "file",
            File = new WebhookFileContent { MediaId = mediaId }
        }, ct);
}

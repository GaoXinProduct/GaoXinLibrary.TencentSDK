using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.GroupChat;
using GaoXinLibrary.TencentSDK.Wecom.Models.Message;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>应用群聊会话管理服务实现</summary>
public class GroupChatService : IGroupChatService
{
    private readonly WecomHttpClient _http;

    public GroupChatService(WecomHttpClient http) => _http = http;

    public async Task<GroupChatInfo> CreateGroupChatAsync(CreateGroupChatRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<CreateGroupChatResponse>("/cgi-bin/appchat/create", request, ct);
        return resp.ChatInfo ?? new GroupChatInfo();
    }

    public async Task UpdateGroupChatAsync(UpdateGroupChatRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/appchat/update", request, ct);

    public async Task<GroupChatInfo> GetGroupChatAsync(string chatId, CancellationToken ct = default)
    {
        var resp = await _http.GetAsync<GetGroupChatResponse>("/cgi-bin/appchat/get",
            new() { ["chatid"] = chatId }, ct);
        return resp.ChatInfo ?? new GroupChatInfo();
    }

    public Task SendTextAsync(string chatId, string content, CancellationToken ct = default)
        => SendAsync(new SendGroupChatMessageRequest
        {
            ChatId = chatId,
            MsgType = "text",
            Text = new TextContent { Content = content }
        }, ct);

    public Task SendNewsAsync(string chatId, NewsArticle[] articles, CancellationToken ct = default)
        => SendAsync(new SendGroupChatMessageRequest
        {
            ChatId = chatId,
            MsgType = "news",
            News = new NewsContent { Articles = articles }
        }, ct);

    public Task SendMarkdownAsync(string chatId, string content, CancellationToken ct = default)
        => SendAsync(new SendGroupChatMessageRequest
        {
            ChatId = chatId,
            MsgType = "markdown",
            Markdown = new MarkdownContent { Content = content }
        }, ct);

    public Task SendFileAsync(string chatId, string mediaId, CancellationToken ct = default)
        => SendAsync(new SendGroupChatMessageRequest
        {
            ChatId = chatId,
            MsgType = "file",
            File = new MediaContent { MediaId = mediaId }
        }, ct);

    public async Task SendAsync(SendGroupChatMessageRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/appchat/send", request, ct);
}

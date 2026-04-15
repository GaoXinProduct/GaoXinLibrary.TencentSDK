using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.GroupChat;
using GaoXinLibrary.TencentSDK.Wecom.Models.Message;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>应用群聊会话管理服务实现</summary>
public class GroupChatService
{
    private readonly WecomHttpClient _http;

    public GroupChatService(WecomHttpClient http) => _http = http;

    /// <summary>创建群聊会话</summary>
    public async Task<GroupChatInfo> CreateGroupChatAsync(CreateGroupChatRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<CreateGroupChatResponse>("/cgi-bin/appchat/create", request, ct);
        return resp.ChatInfo ?? new GroupChatInfo();
    }

    /// <summary>修改群聊会话（改名、换群主、增删成员）</summary>
    public async Task UpdateGroupChatAsync(UpdateGroupChatRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/appchat/update", request, ct);

    /// <summary>获取群聊会话信息</summary>
    public async Task<GroupChatInfo> GetGroupChatAsync(string chatId, CancellationToken ct = default)
    {
        var resp = await _http.GetAsync<GetGroupChatResponse>("/cgi-bin/appchat/get",
            new() { ["chatid"] = chatId }, ct);
        return resp.ChatInfo ?? new GroupChatInfo();
    }

    /// <summary>发送文本消息到群聊</summary>
    public Task SendTextAsync(string chatId, string content, CancellationToken ct = default)
        => SendAsync(new SendGroupChatMessageRequest
        {
            ChatId = chatId,
            MsgType = "text",
            Text = new TextContent { Content = content }
        }, ct);

    /// <summary>发送图文消息到群聊</summary>
    public Task SendNewsAsync(string chatId, NewsArticle[] articles, CancellationToken ct = default)
        => SendAsync(new SendGroupChatMessageRequest
        {
            ChatId = chatId,
            MsgType = "news",
            News = new NewsContent { Articles = articles }
        }, ct);

    /// <summary>发送 Markdown 消息到群聊</summary>
    public Task SendMarkdownAsync(string chatId, string content, CancellationToken ct = default)
        => SendAsync(new SendGroupChatMessageRequest
        {
            ChatId = chatId,
            MsgType = "markdown",
            Markdown = new MarkdownContent { Content = content }
        }, ct);

    /// <summary>发送文件消息到群聊</summary>
    public Task SendFileAsync(string chatId, string mediaId, CancellationToken ct = default)
        => SendAsync(new SendGroupChatMessageRequest
        {
            ChatId = chatId,
            MsgType = "file",
            File = new MediaContent { MediaId = mediaId }
        }, ct);

    /// <summary>发送自定义消息到群聊</summary>
    public async Task SendAsync(SendGroupChatMessageRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/appchat/send", request, ct);
}

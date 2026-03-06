using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.GroupChat;
using GaoXinLibrary.TencentSDK.Wecom.Models.Message;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;


/// <summary>应用群聊会话管理服务接口</summary>
public interface IGroupChatService
{
    /// <summary>创建群聊会话</summary>
    Task<GroupChatInfo> CreateGroupChatAsync(CreateGroupChatRequest request, CancellationToken ct = default);

    /// <summary>修改群聊会话（改名、换群主、增删成员）</summary>
    Task UpdateGroupChatAsync(UpdateGroupChatRequest request, CancellationToken ct = default);

    /// <summary>获取群聊会话信息</summary>
    Task<GroupChatInfo> GetGroupChatAsync(string chatId, CancellationToken ct = default);

    /// <summary>发送文本消息到群聊</summary>
    Task SendTextAsync(string chatId, string content, CancellationToken ct = default);

    /// <summary>发送图文消息到群聊</summary>
    Task SendNewsAsync(string chatId, NewsArticle[] articles, CancellationToken ct = default);

    /// <summary>发送 Markdown 消息到群聊</summary>
    Task SendMarkdownAsync(string chatId, string content, CancellationToken ct = default);

    /// <summary>发送文件消息到群聊</summary>
    Task SendFileAsync(string chatId, string mediaId, CancellationToken ct = default);

    /// <summary>发送自定义消息到群聊</summary>
    Task SendAsync(SendGroupChatMessageRequest request, CancellationToken ct = default);
}

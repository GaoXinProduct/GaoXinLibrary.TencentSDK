using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Message;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;


/// <summary>应用消息发送服务接口</summary>
public interface IMessageService
{
    /// <summary>发送自定义应用消息</summary>
    Task<SendMessageResponse> SendAsync(SendMessageRequest request, CancellationToken ct = default);

    /// <summary>发送文本消息</summary>
    Task<SendMessageResponse> SendTextAsync(string content, string? toUser = null, string? toParty = null, string? toTag = null, int agentId = 0, CancellationToken ct = default);

    /// <summary>发送 Markdown 消息</summary>
    Task<SendMessageResponse> SendMarkdownAsync(string content, string? toUser = null, string? toParty = null, string? toTag = null, int agentId = 0, CancellationToken ct = default);

    /// <summary>发送图片消息</summary>
    Task<SendMessageResponse> SendImageAsync(string mediaId, string? toUser = null, string? toParty = null, string? toTag = null, int agentId = 0, CancellationToken ct = default);

    /// <summary>发送语音消息</summary>
    Task<SendMessageResponse> SendVoiceAsync(string mediaId, string? toUser = null, string? toParty = null, string? toTag = null, int agentId = 0, CancellationToken ct = default);

    /// <summary>发送视频消息</summary>
    Task<SendMessageResponse> SendVideoAsync(VideoContent video, string? toUser = null, string? toParty = null, string? toTag = null, int agentId = 0, CancellationToken ct = default);

    /// <summary>发送文件消息</summary>
    Task<SendMessageResponse> SendFileAsync(string mediaId, string? toUser = null, string? toParty = null, string? toTag = null, int agentId = 0, CancellationToken ct = default);

    /// <summary>发送图文消息</summary>
    Task<SendMessageResponse> SendNewsAsync(NewsArticle[] articles, string? toUser = null, string? toParty = null, string? toTag = null, int agentId = 0, CancellationToken ct = default);

    /// <summary>发送 mpnews 图文消息</summary>
    Task<SendMessageResponse> SendMpNewsAsync(MpNewsArticle[] articles, string? toUser = null, string? toParty = null, string? toTag = null, int agentId = 0, CancellationToken ct = default);

    /// <summary>发送文本卡片消息</summary>
    Task<SendMessageResponse> SendTextCardAsync(TextCardContent card, string? toUser = null, string? toParty = null, string? toTag = null, int agentId = 0, CancellationToken ct = default);

    /// <summary>发送小程序通知消息</summary>
    Task<SendMessageResponse> SendMiniProgramNoticeAsync(MiniProgramNoticeContent notice, string? toUser = null, string? toParty = null, string? toTag = null, int agentId = 0, CancellationToken ct = default);

    /// <summary>发送模版卡片消息（支持 text_notice / news_notice / button_interaction / vote_interaction / multiple_interaction）</summary>
    Task<SendMessageResponse> SendTemplateCardAsync(TemplateCardContent card, string? toUser = null, string? toParty = null, string? toTag = null, int agentId = 0, CancellationToken ct = default);

    /// <summary>更新模版卡片消息</summary>
    Task UpdateTemplateCardAsync(UpdateTemplateCardRequest request, CancellationToken ct = default);

    /// <summary>撤回应用消息</summary>
    Task RecallMessageAsync(string msgId, CancellationToken ct = default);
}

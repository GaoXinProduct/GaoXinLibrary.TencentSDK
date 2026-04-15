using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Message;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

public class MessageService
{
    private readonly WecomHttpClient _http;
    private readonly int _defaultAgentId;

    public MessageService(WecomHttpClient http, int defaultAgentId)
    {
        _http = http;
        _defaultAgentId = defaultAgentId;
    }

    /// <summary>发送自定义应用消息</summary>
    public async Task<SendMessageResponse> SendAsync(SendMessageRequest request, CancellationToken ct = default)
    {
        if (request.AgentId == 0) request.AgentId = _defaultAgentId;
        return await _http.PostAsync<SendMessageResponse>("/cgi-bin/message/send", request, ct);
    }

    /// <summary>发送文本消息</summary>
    public Task<SendMessageResponse> SendTextAsync(string content, string? toUser = null, string? toParty = null, string? toTag = null, int agentId = 0, CancellationToken ct = default)
        => SendAsync(BuildBase("text", toUser, toParty, toTag, agentId) with { Text = new TextContent { Content = content } }, ct);

    /// <summary>发送 Markdown 消息</summary>
    public Task<SendMessageResponse> SendMarkdownAsync(string content, string? toUser = null, string? toParty = null, string? toTag = null, int agentId = 0, CancellationToken ct = default)
        => SendAsync(BuildBase("markdown", toUser, toParty, toTag, agentId) with { Markdown = new MarkdownContent { Content = content } }, ct);

    /// <summary>发送图片消息</summary>
    public Task<SendMessageResponse> SendImageAsync(string mediaId, string? toUser = null, string? toParty = null, string? toTag = null, int agentId = 0, CancellationToken ct = default)
        => SendAsync(BuildBase("image", toUser, toParty, toTag, agentId) with { Image = new MediaContent { MediaId = mediaId } }, ct);

    /// <summary>发送文件消息</summary>
    public Task<SendMessageResponse> SendFileAsync(string mediaId, string? toUser = null, string? toParty = null, string? toTag = null, int agentId = 0, CancellationToken ct = default)
        => SendAsync(BuildBase("file", toUser, toParty, toTag, agentId) with { File = new MediaContent { MediaId = mediaId } }, ct);

    /// <summary>发送图文消息</summary>
    public Task<SendMessageResponse> SendNewsAsync(NewsArticle[] articles, string? toUser = null, string? toParty = null, string? toTag = null, int agentId = 0, CancellationToken ct = default)
        => SendAsync(BuildBase("news", toUser, toParty, toTag, agentId) with { News = new NewsContent { Articles = articles } }, ct);

    /// <summary>发送 mpnews 图文消息</summary>
    public Task<SendMessageResponse> SendMpNewsAsync(MpNewsArticle[] articles, string? toUser = null, string? toParty = null, string? toTag = null, int agentId = 0, CancellationToken ct = default)
        => SendAsync(BuildBase("mpnews", toUser, toParty, toTag, agentId) with { MpNews = new MpNewsContent { Articles = articles } }, ct);

    /// <summary>发送文本卡片消息</summary>
    public Task<SendMessageResponse> SendTextCardAsync(TextCardContent card, string? toUser = null, string? toParty = null, string? toTag = null, int agentId = 0, CancellationToken ct = default)
        => SendAsync(BuildBase("textcard", toUser, toParty, toTag, agentId) with { TextCard = card }, ct);

    /// <summary>发送语音消息</summary>
    public Task<SendMessageResponse> SendVoiceAsync(string mediaId, string? toUser = null, string? toParty = null, string? toTag = null, int agentId = 0, CancellationToken ct = default)
        => SendAsync(BuildBase("voice", toUser, toParty, toTag, agentId) with { Voice = new MediaContent { MediaId = mediaId } }, ct);

    /// <summary>发送视频消息</summary>
    public Task<SendMessageResponse> SendVideoAsync(VideoContent video, string? toUser = null, string? toParty = null, string? toTag = null, int agentId = 0, CancellationToken ct = default)
        => SendAsync(BuildBase("video", toUser, toParty, toTag, agentId) with { Video = video }, ct);

    /// <summary>发送小程序通知消息</summary>
    public Task<SendMessageResponse> SendMiniProgramNoticeAsync(MiniProgramNoticeContent notice, string? toUser = null, string? toParty = null, string? toTag = null, int agentId = 0, CancellationToken ct = default)
        => SendAsync(BuildBase("miniprogram_notice", toUser, toParty, toTag, agentId) with { MiniProgramNotice = notice }, ct);

    /// <summary>发送模版卡片消息（支持 text_notice / news_notice / button_interaction / vote_interaction / multiple_interaction）</summary>
    public Task<SendMessageResponse> SendTemplateCardAsync(TemplateCardContent card, string? toUser = null, string? toParty = null, string? toTag = null, int agentId = 0, CancellationToken ct = default)
        => SendAsync(BuildBase("template_card", toUser, toParty, toTag, agentId) with { TemplateCard = card }, ct);

    /// <summary>更新模版卡片消息</summary>
    public async Task UpdateTemplateCardAsync(UpdateTemplateCardRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/message/update_template_card", request, ct);

    /// <summary>撤回应用消息</summary>
    public async Task RecallMessageAsync(RecallMessageRequest request, CancellationToken ct = default)
        => await _http.PostAsync<RecallMessageResponse>("/cgi-bin/message/recall", request, ct);

    private SendMessageRequest BuildBase(string msgType, string? toUser, string? toParty, string? toTag, int agentId) => new()
    {
        MsgType = msgType,
        ToUser = toUser,
        ToParty = toParty,
        ToTag = toTag,
        AgentId = agentId == 0 ? _defaultAgentId : agentId
    };
}

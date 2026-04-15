using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Message;

#region 发送消息请求基类

/// <summary>发送应用消息请求（支持多种消息类型）</summary>
public record SendMessageRequest
{
    [JsonPropertyName("touser")] public string? ToUser { get; set; }
    [JsonPropertyName("toparty")] public string? ToParty { get; set; }
    [JsonPropertyName("totag")] public string? ToTag { get; set; }
    [JsonPropertyName("msgtype")] public string MsgType { get; set; } = string.Empty;
    [JsonPropertyName("agentid")] public int AgentId { get; set; }
    [JsonPropertyName("text")] public TextContent? Text { get; set; }
    [JsonPropertyName("image")] public MediaContent? Image { get; set; }
    [JsonPropertyName("voice")] public MediaContent? Voice { get; set; }
    [JsonPropertyName("video")] public VideoContent? Video { get; set; }
    [JsonPropertyName("file")] public MediaContent? File { get; set; }
    [JsonPropertyName("textcard")] public TextCardContent? TextCard { get; set; }
    [JsonPropertyName("news")] public NewsContent? News { get; set; }
    [JsonPropertyName("mpnews")] public MpNewsContent? MpNews { get; set; }
    [JsonPropertyName("markdown")] public MarkdownContent? Markdown { get; set; }
    [JsonPropertyName("miniprogram_notice")] public MiniProgramNoticeContent? MiniProgramNotice { get; set; }
    [JsonPropertyName("template_card")] public TemplateCardContent? TemplateCard { get; set; }
    [JsonPropertyName("safe")] public int Safe { get; set; }
    [JsonPropertyName("enable_id_trans")] public int EnableIdTrans { get; set; }
    [JsonPropertyName("enable_duplicate_check")] public int EnableDuplicateCheck { get; set; }
    [JsonPropertyName("duplicate_check_interval")] public int? DuplicateCheckInterval { get; set; }
}

#endregion

using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 发送模板消息请求（POST /cgi-bin/message/template/send）
/// </summary>
public class SendTemplateMessageRequest
{
    /// <summary>接收者 OpenId</summary>
    [JsonPropertyName("touser")] public required string ToUser { get; set; }

    /// <summary>模板 ID</summary>
    [JsonPropertyName("template_id")] public required string TemplateId { get; set; }

    /// <summary>模板跳转链接（可选）</summary>
    [JsonPropertyName("url")] public string? Url { get; set; }

    /// <summary>跳转小程序（可选）</summary>
    [JsonPropertyName("miniprogram")] public TemplateMiniProgram? MiniProgram { get; set; }

    /// <summary>模板数据</summary>
    [JsonPropertyName("data")] public required Dictionary<string, TemplateDataValue> Data { get; set; }

    /// <summary>防重入 ID，64 位整型（可选）</summary>
    [JsonPropertyName("client_msg_id")] public string? ClientMsgId { get; set; }
}


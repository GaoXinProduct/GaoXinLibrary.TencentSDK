using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.MsgAudit;

/// <summary>文本消息内容</summary>
public class MsgAuditText
{
    /// <summary>文本内容</summary>
    [JsonPropertyName("content")] public string? Content { get; set; }
}


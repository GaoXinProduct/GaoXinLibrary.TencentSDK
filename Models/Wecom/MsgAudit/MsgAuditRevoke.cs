using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.MsgAudit;

/// <summary>撤回消息信息</summary>
public class MsgAuditRevoke
{
    /// <summary>被撤回的消息 id</summary>
    [JsonPropertyName("pre_msgid")] public string? PreMsgId { get; set; }
}


using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.MsgAudit;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>获取会话内容存档内部群信息请求</summary>
public class MsgAuditGroupChatGetRequest
{
    /// <summary>待查询的群 roomid</summary>
    [JsonPropertyName("roomid")] public string RoomId { get; set; } = string.Empty;
}


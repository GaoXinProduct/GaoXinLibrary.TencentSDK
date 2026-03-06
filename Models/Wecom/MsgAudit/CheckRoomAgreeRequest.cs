using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.MsgAudit;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>获取群聊会话同意情况请求</summary>
public class CheckRoomAgreeRequest
{
    /// <summary>待查询的 roomid</summary>
    [JsonPropertyName("roomid")] public string RoomId { get; set; } = string.Empty;
}


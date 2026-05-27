using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 查询设备组信息请求（POST /iot/device/group/get）
/// </summary>
public sealed class GetIotGroupInfoRequest
{
    /// <summary>设备组ID</summary>
    [JsonPropertyName("group_id")] public required string GroupId { get; set; }
}
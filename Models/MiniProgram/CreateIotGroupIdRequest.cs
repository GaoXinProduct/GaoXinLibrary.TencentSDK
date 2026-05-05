using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 创建设备组请求（POST /iot/device/group/add）
/// </summary>
public sealed class CreateIotGroupIdRequest
{
    /// <summary>设备组名称</summary>
    [JsonPropertyName("group_name")] public required string GroupName { get; set; }
}
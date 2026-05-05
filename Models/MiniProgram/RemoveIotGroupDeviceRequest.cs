using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 设备组删除设备请求（POST /iot/device/group/del_device）
/// </summary>
public sealed class RemoveIotGroupDeviceRequest
{
    /// <summary>设备组ID</summary>
    [JsonPropertyName("group_id")] public required string GroupId { get; set; }
    /// <summary>设备列表</summary>
    [JsonPropertyName("devices")] public required List<DeviceKey> Devices { get; set; }
}
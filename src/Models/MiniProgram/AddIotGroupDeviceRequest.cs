using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 设备组添加设备请求（POST /iot/device/group/add_device）
/// </summary>
public sealed class AddIotGroupDeviceRequest
{
    /// <summary>设备组ID</summary>
    [JsonPropertyName("group_id")] public required string GroupId { get; set; }
    /// <summary>设备列表</summary>
    [JsonPropertyName("devices")] public required List<DeviceKey> Devices { get; set; }
}

/// <summary>
/// 设备标识
/// </summary>
public sealed class DeviceKey
{
    /// <summary>设备ID</summary>
    [JsonPropertyName("device_id")] public string? DeviceId { get; set; }
    /// <summary>设备序列号</summary>
    [JsonPropertyName("sn")] public string? Sn { get; set; }
}
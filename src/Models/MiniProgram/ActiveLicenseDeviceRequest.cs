using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 激活设备license请求（POST /device/license/device/activate）
/// </summary>
public sealed class ActiveLicenseDeviceRequest
{
    /// <summary>设备序列号</summary>
    [JsonPropertyName("sn")] public required string Sn { get; set; }
    /// <summary>设备类型</summary>
    [JsonPropertyName("device_type")] public required string DeviceType { get; set; }
}
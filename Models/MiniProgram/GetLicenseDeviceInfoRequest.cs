using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 查询设备激活详情请求（POST /device/license/device/info）
/// </summary>
public sealed class GetLicenseDeviceInfoRequest
{
    /// <summary>设备序列号</summary>
    [JsonPropertyName("sn")] public required string Sn { get; set; }
    /// <summary>设备类型</summary>
    [JsonPropertyName("device_type")] public required string DeviceType { get; set; }
}
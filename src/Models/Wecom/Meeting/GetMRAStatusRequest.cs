using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取MRA状态信息请求</summary>
/// <remarks>doc path: /98786</remarks>
public record GetMRAStatusRequest
{
    /// <summary>设备serial</summary>
    [JsonPropertyName("device_serial")]
    public string DeviceSerial { get; init; } = string.Empty;
}
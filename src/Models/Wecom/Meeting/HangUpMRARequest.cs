using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>挂断MRA呼叫请求</summary>
/// <remarks>doc path: /98789</remarks>
public record HangUpMRARequest
{
    /// <summary>设备serial</summary>
    [JsonPropertyName("device_serial")]
    public string DeviceSerial { get; init; } = string.Empty;

    /// <summary>用户userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; init; } = string.Empty;
}
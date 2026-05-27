using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>设置MRA举手或手放下请求</summary>
/// <remarks>doc path: /98788</remarks>
public record SetMRAHandRaiseRequest
{
    /// <summary>设备serial</summary>
    [JsonPropertyName("device_serial")]
    public string DeviceSerial { get; init; } = string.Empty;

    /// <summary>用户userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; init; } = string.Empty;

    /// <summary>操作类型：1-举手，2-放下</summary>
    [JsonPropertyName("operate_type")]
    public int OperateType { get; init; }
}
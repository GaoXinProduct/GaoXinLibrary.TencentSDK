using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>切换MRA默认布局请求</summary>
/// <remarks>doc path: /98787</remarks>
public record SwitchMRALayoutRequest
{
    /// <summary>设备serial</summary>
    [JsonPropertyName("device_serial")]
    public string DeviceSerial { get; init; } = string.Empty;

    /// <summary>用户userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; init; } = string.Empty;

    /// <summary>布局类型：1-宫格，2-演讲者，3-尊享直播</summary>
    [JsonPropertyName("layout_type")]
    public int LayoutType { get; init; }
}
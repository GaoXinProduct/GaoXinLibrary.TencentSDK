using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取设备列表请求</summary>
/// <remarks>doc path: /98798</remarks>
public record GetDeviceListRequest
{
    /// <summary>会议室ID</summary>
    [JsonPropertyName("room_id")]
    public string RoomId { get; init; } = string.Empty;
}
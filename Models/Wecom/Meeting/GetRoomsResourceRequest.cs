using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取Rooms会议室资源请求</summary>
/// <remarks>doc path: /98809</remarks>
public record GetRoomsResourceRequest
{
    /// <summary>会议室ID</summary>
    [JsonPropertyName("room_id")]
    public string RoomId { get; init; } = string.Empty;
}
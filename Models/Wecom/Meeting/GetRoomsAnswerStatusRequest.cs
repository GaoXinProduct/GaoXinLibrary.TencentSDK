using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取Rooms会议室应答状态请求</summary>
/// <remarks>doc path: /98806</remarks>
public record GetRoomsAnswerStatusRequest
{
    /// <summary>会议室ID</summary>
    [JsonPropertyName("room_id")]
    public string RoomId { get; init; } = string.Empty;

    /// <summary>用户userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; init; } = string.Empty;
}
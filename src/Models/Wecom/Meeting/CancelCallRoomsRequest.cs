using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>取消呼叫Rooms会议室请求</summary>
/// <remarks>doc path: /98805</remarks>
public record CancelCallRoomsRequest
{
    /// <summary>会议室ID</summary>
    [JsonPropertyName("room_id")]
    public string RoomId { get; init; } = string.Empty;

    /// <summary>用户userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; init; } = string.Empty;
}
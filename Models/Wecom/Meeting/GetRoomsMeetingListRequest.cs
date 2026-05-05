using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取Rooms会议室下的会议列表请求</summary>
/// <remarks>doc path: /98796</remarks>
public record GetRoomsMeetingListRequest
{
    /// <summary>会议室ID</summary>
    [JsonPropertyName("room_id")]
    public string RoomId { get; init; } = string.Empty;

    /// <summary>返回的最大记录数，最大1000，默认100</summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; init; }

    /// <summary>分页游标</summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; init; }
}
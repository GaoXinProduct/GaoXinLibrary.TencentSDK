using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取实时会中成员列表请求</summary>
/// <remarks>doc path: /98157</remarks>
public record GetRealTimeParticipantsRequest
{
    /// <summary>会议ID</summary>
    [JsonPropertyName("meetingid")]
    public string MeetingId { get; init; } = string.Empty;

    /// <summary>返回的最大记录数，最大3000，默认100</summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; init; }

    /// <summary>分页游标</summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; init; }

    /// <summary>是否需要返回成员房间信息</summary>
    [JsonPropertyName("need_room_info")]
    public bool? NeedRoomInfo { get; init; }
}
using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取实时会中成员列表请求</summary>
/// <remarks>doc path: /98157</remarks>
public record GetRealTimeParticipantsRequest
{
    /// <summary>会议ID</summary>
    [JsonPropertyName("meetingid")]
    public string MeetingId { get; init; } = string.Empty;

    /// <summary>周期性会议的子会议 ID。查询周期性会议时必填。</summary>
    [JsonPropertyName("sub_meetingid")]
    public string? SubMeetingId { get; init; }

    /// <summary>单次请求返回的记录数，最多 50 条。分页时须与首次请求相同。</summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; init; }

    /// <summary>分页游标</summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; init; }

    /// <summary>旧版属性。实时会中成员接口不提供房间信息。</summary>
    [Obsolete("实时会中成员接口不支持 need_room_info。")]
    [JsonIgnore]
    public bool? NeedRoomInfo { get; init; }
}

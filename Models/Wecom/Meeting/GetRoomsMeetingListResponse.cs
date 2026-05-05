using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取Rooms会议室下的会议列表响应</summary>
/// <remarks>doc path: /98796</remarks>
public class GetRoomsMeetingListResponse : WecomBaseResponse
{
    /// <summary>会议室会议列表</summary>
    [JsonPropertyName("room_meetings")]
    public List<RoomMeetingInfo>? RoomMeetings { get; set; }

    /// <summary>分页游标</summary>
    [JsonPropertyName("next_cursor")]
    public string? NextCursor { get; set; }

    /// <summary>是否还有更多数据</summary>
    [JsonPropertyName("has_more")]
    public bool HasMore { get; set; }
}

/// <summary>会议室会议信息</summary>
public class RoomMeetingInfo
{
    /// <summary>会议ID</summary>
    [JsonPropertyName("meetingid")]
    public string? MeetingId { get; set; }

    /// <summary>会议主题</summary>
    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

    /// <summary>会议开始时间（Unix 时间戳，秒）</summary>
    [JsonPropertyName("meeting_start")]
    public long MeetingStart { get; set; }

    /// <summary>会议结束时间（Unix 时间戳，秒）</summary>
    [JsonPropertyName("meeting_end")]
    public long MeetingEnd { get; set; }

    /// <summary>会议状态：0-未开始，1-正在进行，2-已结束，3-已取消</summary>
    [JsonPropertyName("status")]
    public int Status { get; set; }

    /// <summary>主持人userid</summary>
    [JsonPropertyName("host_userid")]
    public string? HostUserId { get; set; }
}
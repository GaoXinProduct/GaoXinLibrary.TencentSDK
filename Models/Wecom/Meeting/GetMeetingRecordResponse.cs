using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取会议发起记录响应</summary>
/// <remarks>doc path: /99651</remarks>
public class GetMeetingRecordResponse : WecomBaseResponse
{
    /// <summary>会议记录列表</summary>
    [JsonPropertyName("meeting_record_list")]
    public List<MeetingRecordItem>? MeetingRecordList { get; set; }

    /// <summary>分页游标</summary>
    [JsonPropertyName("next_cursor")]
    public string? NextCursor { get; set; }

    /// <summary>是否还有更多数据</summary>
    [JsonPropertyName("has_more")]
    public bool HasMore { get; set; }
}

/// <summary>会议记录项</summary>
public class MeetingRecordItem
{
    /// <summary>会议ID</summary>
    [JsonPropertyName("meetingid")]
    public string? MeetingId { get; set; }

    /// <summary>会议号</summary>
    [JsonPropertyName("meeting_code")]
    public string? MeetingCode { get; set; }

    /// <summary>会议标题</summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <summary>会议开始时间（Unix 时间戳，秒）</summary>
    [JsonPropertyName("meeting_start")]
    public long MeetingStart { get; set; }

    /// <summary>会议结束时间（Unix 时间戳，秒）</summary>
    [JsonPropertyName("meeting_end")]
    public long MeetingEnd { get; set; }

    /// <summary>会议状态：0-未开始，1-正在进行，2-已结束，3-已取消</summary>
    [JsonPropertyName("status")]
    public int Status { get; set; }

    /// <summary>会议类型：0-普通会议，1-全员会议</summary>
    [JsonPropertyName("meeting_type")]
    public int MeetingType { get; set; }

    /// <summary>主持人userid</summary>
    [JsonPropertyName("host_userid")]
    public string? HostUserId { get; set; }

    /// <summary>参会人数</summary>
    [JsonPropertyName("attendee_count")]
    public int AttendeeCount { get; set; }

    /// <summary>参会时长（秒）</summary>
    [JsonPropertyName("meeting_duration")]
    public long MeetingDuration { get; set; }
}
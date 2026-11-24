using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>会议信息</summary>
public sealed class MeetingInfo : WecomBaseResponse
{
    /// <summary>会议ID</summary>
    [JsonPropertyName("meetingid")] public string? MeetingId { get; set; }

    /// <summary>会议主题</summary>
    [JsonPropertyName("title")] public string? Title { get; set; }

    /// <summary>会议开始时间（Unix时间戳）</summary>
    [JsonPropertyName("meeting_start")] public long MeetingStart { get; set; }
    /// <summary>会议持续时间（秒）。</summary>
    [JsonPropertyName("meeting_duration")] public long? MeetingDuration { get; set; }

    /// <summary>会议结束时间（Unix时间戳）</summary>
    [JsonPropertyName("meeting_end")] public long MeetingEnd { get; set; }

    /// <summary>会议创建者userid</summary>
    [JsonPropertyName("admin_userid")] public string? AdminUserId { get; set; }

    /// <summary>会议描述</summary>
    [JsonPropertyName("description")] public string? Description { get; set; }
    /// <summary>会议地点。</summary>
    [JsonPropertyName("location")] public string? Location { get; set; }
    /// <summary>会议所属的日历 ID。</summary>
    [JsonPropertyName("cal_id")] public string? CalendarId { get; set; }

    /// <summary>会议类型，0-预约会议，1-快速会议</summary>
    [JsonPropertyName("meeting_type")] public int MeetingType { get; set; }

    /// <summary>会议号</summary>
    [JsonPropertyName("meeting_code")] public string? MeetingCode { get; set; }

    /// <summary>会议状态，1-待开始，2-进行中，3-已结束，4-已取消，5-已过期。</summary>
    [JsonPropertyName("status")] public int Status { get; set; }

    /// <summary>入会链接。</summary>
    [JsonPropertyName("meeting_link")] public string? MeetingLink { get; set; }

    [JsonInclude]
    [JsonPropertyName("meeting_info")]
    internal MeetingInfo? LegacyMeetingInfo { get; private set; }
}

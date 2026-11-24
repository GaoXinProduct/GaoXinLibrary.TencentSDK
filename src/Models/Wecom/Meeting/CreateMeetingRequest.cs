
namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>创建会议请求</summary>
public sealed class CreateMeetingRequest
{
    private long? _meetingDuration;

    /// <summary>会议标题</summary>
    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    /// <summary>会议开始时间（Unix 时间戳，秒）</summary>
    [JsonPropertyName("meeting_start")]
    public long MeetingStart { get; set; }

    /// <summary>会议结束时间（Unix 时间戳，秒）。未指定时长时由开始和结束时间计算。</summary>
    [JsonIgnore]
    public long MeetingEnd { get; set; }

    /// <summary>会议持续时间（秒，300 至 86399）。</summary>
    [JsonPropertyName("meeting_duration")]
    public long? MeetingDuration
    {
        get => _meetingDuration ?? (MeetingEnd == 0 ? null : checked(MeetingEnd - MeetingStart));
        set => _meetingDuration = value;
    }

    /// <summary>管理员 userid</summary>
    [JsonPropertyName("admin_userid")]
    public string AdminUserId { get; set; } = string.Empty;

    /// <summary>会议描述</summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>会议地点。</summary>
    [JsonPropertyName("location")]
    public string? Location { get; set; }

    /// <summary>会议所属的日历 ID。</summary>
    [JsonPropertyName("cal_id")]
    public string? CalendarId { get; set; }
}

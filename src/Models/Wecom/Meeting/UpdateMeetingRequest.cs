
namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>修改会议请求</summary>
public sealed class UpdateMeetingRequest
{
    private long? _meetingDuration;

    /// <summary>会议 ID</summary>
    [JsonPropertyName("meetingid")]
    public string MeetingId { get; set; } = string.Empty;

    /// <summary>会议标题</summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <summary>会议开始时间（Unix 时间戳，秒）</summary>
    [JsonPropertyName("meeting_start")]
    public long? MeetingStart { get; set; }

    /// <summary>会议结束时间（Unix 时间戳，秒）。可与开始时间一起用于计算时长。</summary>
    [JsonIgnore]
    public long? MeetingEnd { get; set; }

    /// <summary>会议持续时间（秒，300 至 86399），修改时须同时提供开始时间。</summary>
    [JsonPropertyName("meeting_duration")]
    public long? MeetingDuration
    {
        get => _meetingDuration ?? checked(MeetingEnd - MeetingStart);
        set => _meetingDuration = value;
    }

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

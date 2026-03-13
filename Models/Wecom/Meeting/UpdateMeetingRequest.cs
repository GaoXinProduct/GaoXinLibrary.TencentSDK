using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>修改会议请求</summary>
public class UpdateMeetingRequest
{
    /// <summary>会议 ID</summary>
    [JsonPropertyName("meetingid")]
    public string MeetingId { get; set; } = string.Empty;

    /// <summary>会议标题</summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <summary>会议开始时间（Unix 时间戳，秒）</summary>
    [JsonPropertyName("meeting_start")]
    public long? MeetingStart { get; set; }

    /// <summary>会议结束时间（Unix 时间戳，秒）</summary>
    [JsonPropertyName("meeting_end")]
    public long? MeetingEnd { get; set; }

    /// <summary>会议描述</summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }
}

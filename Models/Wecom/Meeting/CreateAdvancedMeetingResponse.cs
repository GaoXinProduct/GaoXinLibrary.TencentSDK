using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>创建预约会议响应</summary>
/// <remarks>doc path: /98148</remarks>
public class CreateAdvancedMeetingResponse : WecomBaseResponse
{
    /// <summary>会议ID</summary>
    [JsonPropertyName("meetingid")]
    public string? MeetingId { get; set; }

    /// <summary>会议号</summary>
    [JsonPropertyName("meeting_code")]
    public string? MeetingCode { get; set; }

    /// <summary>入会链接</summary>
    [JsonPropertyName("join_url")]
    public string? JoinUrl { get; set; }

    /// <summary>直播链接</summary>
    [JsonPropertyName("live_url")]
    public string? LiveUrl { get; set; }
}
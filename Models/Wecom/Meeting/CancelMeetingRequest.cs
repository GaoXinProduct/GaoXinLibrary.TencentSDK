using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>取消会议请求</summary>
public class CancelMeetingRequest
{
    /// <summary>会议 ID</summary>
    [JsonPropertyName("meetingid")]
    public string MeetingId { get; set; } = string.Empty;
}

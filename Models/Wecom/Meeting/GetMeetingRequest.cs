using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取会议详情请求</summary>
public class GetMeetingRequest
{
    /// <summary>会议 ID</summary>
    [JsonPropertyName("meetingid")]
    public string MeetingId { get; set; } = string.Empty;
}

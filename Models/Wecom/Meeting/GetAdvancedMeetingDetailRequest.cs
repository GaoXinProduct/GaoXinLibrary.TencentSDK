using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取预约会议详情请求</summary>
/// <remarks>doc path: /98149</remarks>
public record GetAdvancedMeetingDetailRequest
{
    /// <summary>会议ID</summary>
    [JsonPropertyName("meetingid")]
    public string MeetingId { get; init; } = string.Empty;

    /// <summary>返回的直播链接，仅会议创建者可获取</summary>
    [JsonPropertyName("with_live_url")]
    public bool? WithLiveUrl { get; init; }
}
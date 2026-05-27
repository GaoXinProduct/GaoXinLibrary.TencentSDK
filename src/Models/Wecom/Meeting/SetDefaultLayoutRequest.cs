using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>设置会议默认布局请求</summary>
/// <remarks>doc path: /98847</remarks>
public record SetDefaultLayoutRequest
{
    /// <summary>会议ID</summary>
    [JsonPropertyName("meetingid")]
    public string MeetingId { get; init; } = string.Empty;

    /// <summary>用户userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; init; } = string.Empty;

    /// <summary>布局模板ID</summary>
    [JsonPropertyName("layout_template_id")]
    public string LayoutTemplateId { get; init; } = string.Empty;
}
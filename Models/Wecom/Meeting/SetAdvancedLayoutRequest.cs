using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>设置高级布局请求</summary>
/// <remarks>doc path: /98869</remarks>
public record SetAdvancedLayoutRequest
{
    /// <summary>会议ID</summary>
    [JsonPropertyName("meetingid")]
    public string MeetingId { get; init; } = string.Empty;

    /// <summary>用户userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; init; } = string.Empty;

    /// <summary>布局ID</summary>
    [JsonPropertyName("layout_id")]
    public string LayoutId { get; init; } = string.Empty;

    /// <summary>是否为默认布局</summary>
    [JsonPropertyName("is_default")]
    public bool? IsDefault { get; init; }
}
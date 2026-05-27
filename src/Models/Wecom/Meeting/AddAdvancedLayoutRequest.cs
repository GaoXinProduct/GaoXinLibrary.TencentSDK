using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>添加会议高级布局请求</summary>
/// <remarks>doc path: /98861</remarks>
public record AddAdvancedLayoutRequest
{
    /// <summary>会议ID</summary>
    [JsonPropertyName("meetingid")]
    public string MeetingId { get; init; } = string.Empty;

    /// <summary>用户userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; init; } = string.Empty;

    /// <summary>布局配置（JSON格式）</summary>
    [JsonPropertyName("layout_config")]
    public string? LayoutConfig { get; init; }
}
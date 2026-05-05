using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>创建用户专属参会链接请求</summary>
/// <remarks>doc path: /98818</remarks>
public record CreateUserMeetingLinkRequest
{
    /// <summary>用户userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; init; } = string.Empty;

    /// <summary>会议ID</summary>
    [JsonPropertyName("meetingid")]
    public string? MeetingId { get; init; }

    /// <summary>链接类型：1-入会链接，2-成为主持人链接</summary>
    [JsonPropertyName("link_type")]
    public int LinkType { get; init; }
}
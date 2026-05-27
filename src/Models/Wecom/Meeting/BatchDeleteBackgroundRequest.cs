using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>批量删除背景请求</summary>
/// <remarks>doc path: /98854</remarks>
public record BatchDeleteBackgroundRequest
{
    /// <summary>会议ID</summary>
    [JsonPropertyName("meetingid")]
    public string MeetingId { get; init; } = string.Empty;

    /// <summary>用户userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; init; } = string.Empty;

    /// <summary>背景ID列表</summary>
    [JsonPropertyName("background_id_list")]
    public List<string> BackgroundIdList { get; init; } = new();
}
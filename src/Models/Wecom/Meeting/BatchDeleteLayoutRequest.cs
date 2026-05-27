using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>批量删除布局请求</summary>
/// <remarks>doc path: /98866</remarks>
public record BatchDeleteLayoutRequest
{
    /// <summary>会议ID</summary>
    [JsonPropertyName("meetingid")]
    public string MeetingId { get; init; } = string.Empty;

    /// <summary>用户userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; init; } = string.Empty;

    /// <summary>布局ID列表</summary>
    [JsonPropertyName("layout_id_list")]
    public List<string> LayoutIdList { get; init; } = new();
}
using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>移出成员请求</summary>
/// <remarks>doc path: /98181</remarks>
public record RemoveMeetingMemberRequest
{
    /// <summary>会议ID</summary>
    [JsonPropertyName("meetingid")]
    public string MeetingId { get; init; } = string.Empty;

    /// <summary>用户userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; init; } = string.Empty;

    /// <summary>被移出的成员userid列表</summary>
    [JsonPropertyName("userid_list")]
    public List<string> UserIdList { get; init; } = new();

    /// <summary>是否同时移除其参会链接</summary>
    [JsonPropertyName("remove_meeting_link")]
    public bool? RemoveMeetingLink { get; init; }
}
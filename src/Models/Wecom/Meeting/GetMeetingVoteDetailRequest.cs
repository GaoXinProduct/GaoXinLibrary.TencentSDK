using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取会议投票主题信息请求</summary>
/// <remarks>doc path: /98837</remarks>
public record GetMeetingVoteDetailRequest
{
    /// <summary>会议ID</summary>
    [JsonPropertyName("meetingid")]
    public string MeetingId { get; init; } = string.Empty;

    /// <summary>投票ID</summary>
    [JsonPropertyName("vote_id")]
    public string VoteId { get; init; } = string.Empty;
}
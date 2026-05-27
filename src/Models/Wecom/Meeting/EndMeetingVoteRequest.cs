using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>结束会议投票请求</summary>
/// <remarks>doc path: /98841</remarks>
public record EndMeetingVoteRequest
{
    /// <summary>会议ID</summary>
    [JsonPropertyName("meetingid")]
    public string MeetingId { get; init; } = string.Empty;

    /// <summary>用户userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; init; } = string.Empty;

    /// <summary>投票ID</summary>
    [JsonPropertyName("vote_id")]
    public string VoteId { get; init; } = string.Empty;
}
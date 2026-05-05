using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取会议投票详情请求</summary>
/// <remarks>doc path: /98838</remarks>
public record GetMeetingVoteInfoRequest
{
    /// <summary>会议ID</summary>
    [JsonPropertyName("meetingid")]
    public string MeetingId { get; init; } = string.Empty;

    /// <summary>投票ID</summary>
    [JsonPropertyName("vote_id")]
    public string VoteId { get; init; } = string.Empty;
}
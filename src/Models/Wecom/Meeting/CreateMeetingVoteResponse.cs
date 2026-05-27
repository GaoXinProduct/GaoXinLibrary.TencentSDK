using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>创建会议投票主题响应</summary>
/// <remarks>doc path: /98834</remarks>
public class CreateMeetingVoteResponse : WecomBaseResponse
{
    /// <summary>投票ID</summary>
    [JsonPropertyName("vote_id")]
    public string? VoteId { get; set; }
}
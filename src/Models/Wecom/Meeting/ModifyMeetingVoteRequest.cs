using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>修改会议投票主题请求</summary>
/// <remarks>doc path: /98835</remarks>
public record ModifyMeetingVoteRequest
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

    /// <summary>投票标题</summary>
    [JsonPropertyName("vote_title")]
    public string? VoteTitle { get; init; }

    /// <summary>投票内容</summary>
    [JsonPropertyName("vote_content")]
    public string? VoteContent { get; init; }

    /// <summary>投票选项列表</summary>
    [JsonPropertyName("vote_options")]
    public List<string>? VoteOptions { get; init; }

    /// <summary>是否多选</summary>
    [JsonPropertyName("is_multiple")]
    public bool? IsMultiple { get; init; }

    /// <summary>是否匿名投票</summary>
    [JsonPropertyName("is_anonymous")]
    public bool? IsAnonymous { get; init; }

    /// <summary>投票截止时间（Unix 时间戳，秒）</summary>
    [JsonPropertyName("deadline")]
    public long? Deadline { get; init; }
}
using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取会议投票主题信息响应</summary>
/// <remarks>doc path: /98837</remarks>
public class GetMeetingVoteDetailResponse : WecomBaseResponse
{
    /// <summary>投票详情</summary>
    [JsonPropertyName("vote_detail")]
    public MeetingVoteDetailInfo? VoteDetail { get; set; }
}

/// <summary>会议投票详情信息</summary>
public class MeetingVoteDetailInfo
{
    /// <summary>投票ID</summary>
    [JsonPropertyName("vote_id")]
    public string? VoteId { get; set; }

    /// <summary>投票标题</summary>
    [JsonPropertyName("vote_title")]
    public string? VoteTitle { get; set; }

    /// <summary>投票内容</summary>
    [JsonPropertyName("vote_content")]
    public string? VoteContent { get; set; }

    /// <summary>投票选项列表</summary>
    [JsonPropertyName("vote_options")]
    public List<string>? VoteOptions { get; set; }

    /// <summary>是否多选</summary>
    [JsonPropertyName("is_multiple")]
    public bool IsMultiple { get; set; }

    /// <summary>是否匿名投票</summary>
    [JsonPropertyName("is_anonymous")]
    public bool IsAnonymous { get; set; }

    /// <summary>投票状态：1-未开始，2-进行中，3-已结束</summary>
    [JsonPropertyName("status")]
    public int Status { get; set; }

    /// <summary>投票截止时间（Unix 时间戳，秒）</summary>
    [JsonPropertyName("deadline")]
    public long Deadline { get; set; }

    /// <summary>投票发起时间（Unix 时间戳，秒）</summary>
    [JsonPropertyName("create_time")]
    public long CreateTime { get; set; }
}
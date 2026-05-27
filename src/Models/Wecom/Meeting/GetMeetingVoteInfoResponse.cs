using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取会议投票详情响应</summary>
/// <remarks>doc path: /98838</remarks>
public class GetMeetingVoteInfoResponse : WecomBaseResponse
{
    /// <summary>投票结果信息</summary>
    [JsonPropertyName("vote_result")]
    public MeetingVoteResultInfo? VoteResult { get; set; }
}

/// <summary>会议投票结果信息</summary>
public class MeetingVoteResultInfo
{
    /// <summary>投票ID</summary>
    [JsonPropertyName("vote_id")]
    public string? VoteId { get; set; }

    /// <summary>投票标题</summary>
    [JsonPropertyName("vote_title")]
    public string? VoteTitle { get; set; }

    /// <summary>投票状态：1-未开始，2-进行中，3-已结束</summary>
    [JsonPropertyName("status")]
    public int Status { get; set; }

    /// <summary>投票选项结果列表</summary>
    [JsonPropertyName("option_results")]
    public List<VoteOptionResult>? OptionResults { get; set; }

    /// <summary>总投票人数</summary>
    [JsonPropertyName("total_vote_count")]
    public int TotalVoteCount { get; set; }
}

/// <summary>投票选项结果</summary>
public class VoteOptionResult
{
    /// <summary>选项内容</summary>
    [JsonPropertyName("option")]
    public string? Option { get; set; }

    /// <summary>投票人数</summary>
    [JsonPropertyName("vote_count")]
    public int VoteCount { get; set; }

    /// <summary>投票比例（百分比）</summary>
    [JsonPropertyName("vote_ratio")]
    public double VoteRatio { get; set; }
}
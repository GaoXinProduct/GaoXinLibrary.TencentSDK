using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取会议投票列表响应</summary>
/// <remarks>doc path: /98836</remarks>
public class GetMeetingVoteListResponse : WecomBaseResponse
{
    /// <summary>投票列表</summary>
    [JsonPropertyName("vote_list")]
    public List<MeetingVoteBasicInfo>? VoteList { get; set; }
}

/// <summary>会议投票基本信息</summary>
public class MeetingVoteBasicInfo
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

    /// <summary>是否匿名投票</summary>
    [JsonPropertyName("is_anonymous")]
    public bool IsAnonymous { get; set; }

    /// <summary>投票发起时间（Unix 时间戳，秒）</summary>
    [JsonPropertyName("create_time")]
    public long CreateTime { get; set; }
}
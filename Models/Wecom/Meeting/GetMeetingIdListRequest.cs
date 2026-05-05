using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取成员会议ID列表请求</summary>
/// <remarks>doc path: /99050</remarks>
public record GetMeetingIdListRequest
{
    /// <summary>用户userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; init; } = string.Empty;

    /// <summary>返回的最大记录数，最大1000，默认100</summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; init; }

    /// <summary>分页游标（用于加载更多数据）</summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; init; }

    /// <summary>会议状态筛选：0-全部，1-未开始，2-进行中，3-已结束</summary>
    [JsonPropertyName("status")]
    public int? Status { get; init; }

    /// <summary>会议类型：0-全部，1-普通会议，2-网络研讨会</summary>
    [JsonPropertyName("meeting_type")]
    public int? MeetingType { get; init; }
}
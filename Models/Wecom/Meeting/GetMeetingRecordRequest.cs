using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取会议发起记录请求</summary>
/// <remarks>doc path: /99651</remarks>
public record GetMeetingRecordRequest
{
    /// <summary>请求起始时间（Unix 时间戳，秒）</summary>
    [JsonPropertyName("record_start_time")]
    public long? RecordStartTime { get; init; }

    /// <summary>请求结束时间（Unix 时间戳，秒）</summary>
    [JsonPropertyName("record_end_time")]
    public long? RecordEndTime { get; init; }

    /// <summary>返回的最大记录数，最大1000，默认100</summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; init; }

    /// <summary>分页游标</summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; init; }

    /// <summary>主持人userid</summary>
    [JsonPropertyName("host_userid")]
    public string? HostUserId { get; init; }

    /// <summary>会议类型：0-全部，1-普通会议，2-网络研讨会</summary>
    [JsonPropertyName("meeting_type")]
    public int? MeetingType { get; init; }
}
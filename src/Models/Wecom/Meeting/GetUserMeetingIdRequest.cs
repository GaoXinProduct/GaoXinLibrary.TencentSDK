
namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取用户会议 ID 列表请求</summary>
public sealed class GetUserMeetingIdRequest
{
    /// <summary>用户 userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; set; } = string.Empty;

    /// <summary>分页游标</summary>
    [JsonPropertyName("cursor")]
    public string Cursor { get; set; } = string.Empty;

    /// <summary>每页大小</summary>
    [JsonPropertyName("limit")]
    public int Limit { get; set; } = 20;

    /// <summary>查询开始时间（Unix 时间戳，秒）。</summary>
    [JsonPropertyName("begin_time")]
    public long? BeginTime { get; set; }

    /// <summary>查询结束时间（Unix 时间戳，秒）。查询时间跨度最多为 180 天。</summary>
    [JsonPropertyName("end_time")]
    public long? EndTime { get; set; }
}

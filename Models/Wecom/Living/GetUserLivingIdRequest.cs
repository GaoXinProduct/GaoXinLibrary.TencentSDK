using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Living;

/// <summary>获取成员直播 ID 列表请求</summary>
public class GetUserLivingIdRequest
{
    /// <summary>成员的 userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; set; } = string.Empty;

    /// <summary>开始时间（Unix 时间戳，秒）</summary>
    [JsonPropertyName("begin_time")]
    public long BeginTime { get; set; }

    /// <summary>结束时间（Unix 时间戳，秒）</summary>
    [JsonPropertyName("end_time")]
    public long EndTime { get; set; }

    /// <summary>分页游标（可选，首次请求不填）</summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

    /// <summary>每页大小，默认 100，最大 100</summary>
    [JsonPropertyName("limit")]
    public int Limit { get; set; } = 100;
}

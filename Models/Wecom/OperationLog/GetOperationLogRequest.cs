using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.OperationLog;

/// <summary>获取操作日志请求</summary>
public class GetOperationLogRequest
{
    /// <summary>起始时间（Unix 时间戳，秒）</summary>
    [JsonPropertyName("start_time")]
    public long StartTime { get; set; }

    /// <summary>结束时间（Unix 时间戳，秒）</summary>
    [JsonPropertyName("end_time")]
    public long EndTime { get; set; }

    /// <summary>分页游标</summary>
    [JsonPropertyName("cursor")]
    public string Cursor { get; set; } = string.Empty;

    /// <summary>每页大小</summary>
    [JsonPropertyName("limit")]
    public int Limit { get; set; } = 100;
}

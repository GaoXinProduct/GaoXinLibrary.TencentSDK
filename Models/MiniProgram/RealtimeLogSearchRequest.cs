using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>
/// 查询实时日志请求（GET /wxaapi/userlog/userlog_search）
/// </summary>
public class RealtimeLogSearchRequest
{
    /// <summary>日期（格式 YYYYMMDD，必填）</summary>
    [JsonPropertyName("date")]       public string? Date { get; set; }
    /// <summary>开始时间戳（Unix 秒）</summary>
    [JsonPropertyName("begintime")]  public long BeginTime { get; set; }
    /// <summary>结束时间戳（Unix 秒）</summary>
    [JsonPropertyName("endtime")]    public long EndTime { get; set; }
    /// <summary>日志topic（可选）</summary>
    [JsonPropertyName("topic")]      public string? Topic { get; set; }
    /// <summary>小程序环境（release/trial/develop，可选）</summary>
    [JsonPropertyName("env")]        public string? Env { get; set; }
    /// <summary>最多返回条数（默认20，最大100）</summary>
    [JsonPropertyName("limit")]      public int Limit { get; set; } = 20;
    /// <summary>分页偏移</summary>
    [JsonPropertyName("start")]      public int Start { get; set; }
    /// <summary>过滤traceId（可选）</summary>
    [JsonPropertyName("traceId")]    public string? TraceId { get; set; }
    /// <summary>过滤关键词（可选）</summary>
    [JsonPropertyName("filterMsg")]  public string? FilterMsg { get; set; }
}

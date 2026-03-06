using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>查询实时日志响应</summary>
public class RealtimeLogSearchResponse : WechatBaseResponse
{
    /// <summary>日志总条数</summary>
    [JsonPropertyName("total")]    public int Total { get; set; }
    /// <summary>日志列表</summary>
    [JsonPropertyName("log_list")] public List<RealtimeLogItem>? LogList { get; set; }
}

/// <summary>实时日志单条</summary>
public class RealtimeLogItem
{
    [JsonPropertyName("timestamp")]  public long Timestamp { get; set; }
    [JsonPropertyName("traceId")]    public string? TraceId { get; set; }
    [JsonPropertyName("openid")]     public string? OpenId { get; set; }
    [JsonPropertyName("clientInfo")] public string? ClientInfo { get; set; }
    [JsonPropertyName("content")]    public string? Content { get; set; }
    [JsonPropertyName("level")]      public int Level { get; set; }
}

using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>rid 请求信息</summary>
public class RidRequestInfo
{
    /// <summary>发起请求的时间戳</summary>
    [JsonPropertyName("invoke_time")] public long InvokeTime { get; set; }
    /// <summary>请求毫秒级耗时</summary>
    [JsonPropertyName("cost_in_ms")] public long CostInMs { get; set; }
    /// <summary>请求的 URL</summary>
    [JsonPropertyName("request_url")] public string? RequestUrl { get; set; }
    /// <summary>请求的 Body</summary>
    [JsonPropertyName("request_body")] public string? RequestBody { get; set; }
    /// <summary>响应的 Body</summary>
    [JsonPropertyName("response_body")] public string? ResponseBody { get; set; }
}


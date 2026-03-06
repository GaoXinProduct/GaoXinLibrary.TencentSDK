using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>rid 对应的请求信息</summary>
public class OfficialRidRequestInfo
{
    [JsonPropertyName("invoke_time")] public long InvokeTime { get; set; }
    [JsonPropertyName("cost_in_ms")] public int CostInMs { get; set; }
    [JsonPropertyName("request_url")] public string? RequestUrl { get; set; }
    [JsonPropertyName("request_body")] public string? RequestBody { get; set; }
    [JsonPropertyName("response_body")] public string? ResponseBody { get; set; }
}


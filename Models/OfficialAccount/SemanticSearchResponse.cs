using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>语义理解响应</summary>
public class SemanticSearchResponse : WechatBaseResponse
{
    [JsonPropertyName("query")] public string? Query { get; set; }
    [JsonPropertyName("type")] public string? Type { get; set; }
    [JsonPropertyName("semantic")] public object? Semantic { get; set; }
}


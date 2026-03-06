using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>语义理解请求（POST /semantic/semproxy/search）</summary>
public class SemanticSearchRequest
{
    [JsonPropertyName("query")] public required string Query { get; set; }
    [JsonPropertyName("city")] public required string City { get; set; }
    [JsonPropertyName("category")] public required string Category { get; set; }
    [JsonPropertyName("uid")] public required string Uid { get; set; }
}


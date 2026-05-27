using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 查询scheme码请求（POST /wxa/queryscheme）
/// </summary>
public sealed class QuerySchemeRequest
{
    /// <summary>scheme内容</summary>
    [JsonPropertyName("scheme")] public required string Scheme { get; set; }
}

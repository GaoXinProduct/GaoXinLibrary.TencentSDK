// ═══════════════════════════════════════════════════════════════════════════

using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>
/// 获取类目下的公共模板请求（GET /wxa/get_pub_template_titles）
/// </summary>
public sealed class GetPubTemplateTitlesRequest
{
    /// <summary>类目ID列表（多个ID用逗号分隔）</summary>
    [JsonPropertyName("ids")] public required string Ids { get; set; }
    
    /// <summary>偏移量，默认0</summary>
    [JsonPropertyName("start")] public int Start { get; set; } = 0;
    
    /// <summary>每页数量，默认10</summary>
    [JsonPropertyName("limit")] public int Limit { get; set; } = 10;
}
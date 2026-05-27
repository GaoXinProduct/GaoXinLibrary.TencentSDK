// ═══════════════════════════════════════════════════════════════════════════

using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>
/// 获取模板中的关键词请求（GET /wxa/get_pub_template_keywords）
/// </summary>
public sealed class GetPubTemplateKeywordsRequest
{
    /// <summary>模板标题ID</summary>
    [JsonPropertyName("tid")] public required int TemplateId { get; set; }
}
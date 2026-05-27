// ═══════════════════════════════════════════════════════════════════════════

using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>
/// 删除模板请求（POST /wxa/del_template）
/// </summary>
public sealed class DelTemplateRequest
{
    /// <summary>模板ID</summary>
    [JsonPropertyName("pri_tmpl_id")] public required string TemplateId { get; set; }
}
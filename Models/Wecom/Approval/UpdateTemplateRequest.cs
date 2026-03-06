using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>更新审批模板请求</summary>
public class UpdateTemplateRequest
{
    /// <summary>模板 id</summary>
    [JsonPropertyName("template_id")] public string TemplateId { get; set; } = string.Empty;

    /// <summary>模板名称（多语言）</summary>
    [JsonPropertyName("template_name")] public ApprovalText[]? TemplateName { get; set; }

    /// <summary>模板控件</summary>
    [JsonPropertyName("template_content")] public TemplateContent? TemplateContent { get; set; }
}


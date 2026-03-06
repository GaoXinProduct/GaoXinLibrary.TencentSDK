using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>获取审批模板详情请求</summary>
public class GetTemplateDetailRequest
{
    /// <summary>模板的唯一标识 id</summary>
    [JsonPropertyName("template_id")] public string TemplateId { get; set; } = string.Empty;
}


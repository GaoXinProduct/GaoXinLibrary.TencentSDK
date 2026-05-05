using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval.Workflow;

/// <summary>获取审批模板详情请求（新版）</summary>
public record GetWorkflowDetailRequest
{
    /// <summary>模板 id</summary>
    [JsonPropertyName("template_id")]
    public string TemplateId { get; init; } = string.Empty;
}
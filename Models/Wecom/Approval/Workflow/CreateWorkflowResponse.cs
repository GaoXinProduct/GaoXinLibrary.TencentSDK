using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval.Workflow;

/// <summary>创建审批模板响应（新版）</summary>
public class CreateWorkflowResponse : WecomBaseResponse
{
    /// <summary>模板 id</summary>
    [JsonPropertyName("template_id")]
    public string? TemplateId { get; set; }

    /// <summary>创建时间（Unix 时间戳）</summary>
    [JsonPropertyName("create_time")]
    public long CreateTime { get; set; }
}
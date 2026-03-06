using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

/// <summary>创建审批模板响应</summary>
public class CreateTemplateResponse : WecomBaseResponse
{
    /// <summary>模板 id</summary>
    [JsonPropertyName("template_id")] public string? TemplateId { get; set; }
}


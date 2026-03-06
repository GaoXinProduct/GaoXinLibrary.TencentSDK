using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

/// <summary>获取审批模板详情响应</summary>
public class GetTemplateDetailResponse : WecomBaseResponse
{
    /// <summary>模板名称</summary>
    [JsonPropertyName("template_names")] public ApprovalText[]? TemplateNames { get; set; }

    /// <summary>模板控件信息</summary>
    [JsonPropertyName("template_content")] public TemplateContent? TemplateContent { get; set; }
}


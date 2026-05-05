using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval.Workflow;

/// <summary>创建审批模板请求（新版）</summary>
public record CreateWorkflowRequest
{
    /// <summary>模板名称</summary>
    [JsonPropertyName("template_name")]
    public string TemplateName { get; init; } = string.Empty;

    /// <summary>模板控件列表</summary>
    [JsonPropertyName("template_title")]
    public WorkflowTemplateTitle[]? TemplateTitle { get; init; }

    /// <summary>是否使用标签</summary>
    [JsonPropertyName("use_template_avatar")]
    public int? UseTemplateAvatar { get; init; }

    /// <summary>是否隐藏模板</summary>
    [JsonPropertyName("hide_template_avatar")]
    public int? HideTemplateAvatar { get; init; }

    /// <summary>是否开启让发起人自选审批人</summary>
    [JsonPropertyName("choose_approver")]
    public int? ChooseApprover { get; init; }

    /// <summary>审批流程节点列表</summary>
    [JsonPropertyName("nodes")]
    public WorkflowNodeInfo[]? Nodes { get; init; }

    /// <summary>触发条件规则</summary>
    [JsonPropertyName("trigger_rule")]
    public WorkflowTriggerRule? TriggerRule { get; init; }
}

/// <summary>模板标题（多语言）</summary>
public class WorkflowTemplateTitle
{
    /// <summary>语言</summary>
    [JsonPropertyName("lang")]
    public string Lang { get; set; } = "zh_CN";

    /// <summary>标题文本</summary>
    [JsonPropertyName("text")]
    public string Text { get; set; } = string.Empty;
}
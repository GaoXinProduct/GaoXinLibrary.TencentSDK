using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval.Workflow;

/// <summary>获取审批模板详情响应（新版）</summary>
public class GetWorkflowDetailResponse : WecomBaseResponse
{
    /// <summary>模板 id</summary>
    [JsonPropertyName("template_id")]
    public string? TemplateId { get; set; }

    /// <summary>模板名称</summary>
    [JsonPropertyName("template_name")]
    public string? TemplateName { get; set; }

    /// <summary>模板标题（多语言）</summary>
    [JsonPropertyName("template_title")]
    public WorkflowTemplateTitle[]? TemplateTitle { get; set; }

    /// <summary>是否使用标签</summary>
    [JsonPropertyName("use_template_avatar")]
    public int UseTemplateAvatar { get; set; }

    /// <summary>是否隐藏模板</summary>
    [JsonPropertyName("hide_template_avatar")]
    public int HideTemplateAvatar { get; set; }

    /// <summary>是否开启让发起人自选审批人</summary>
    [JsonPropertyName("choose_approver")]
    public int ChooseApprover { get; set; }

    /// <summary>审批流程节点列表</summary>
    [JsonPropertyName("nodes")]
    public WorkflowNodeInfo[]? Nodes { get; set; }

    /// <summary>触发条件规则</summary>
    [JsonPropertyName("trigger_rule")]
    public WorkflowTriggerRule? TriggerRule { get; set; }

    /// <summary>创建时间（Unix 时间戳）</summary>
    [JsonPropertyName("create_time")]
    public long CreateTime { get; set; }

    /// <summary>更新时间（Unix 时间戳）</summary>
    [JsonPropertyName("update_time")]
    public long UpdateTime { get; set; }
}
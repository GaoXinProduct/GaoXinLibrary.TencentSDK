using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval.Workflow;

/// <summary>审批流程节点信息</summary>
public class WorkflowNodeInfo
{
    /// <summary>节点 id</summary>
    [JsonPropertyName("node_id")]
    public int NodeId { get; set; }

    /// <summary>节点名称</summary>
    [JsonPropertyName("node_name")]
    public string? NodeName { get; set; }

    /// <summary>节点类型：1-开始 2-审批 3-抄送 4-结束</summary>
    [JsonPropertyName("node_type")]
    public int NodeType { get; set; }

    /// <summary>审批节点属性</summary>
    [JsonPropertyName("attr")]
    public WorkflowNodeAttr? Attr { get; set; }

    /// <summary>节点控件列表</summary>
    [JsonPropertyName("controls")]
    public WorkflowControlInfo[]? Controls { get; set; }

    /// <summary>节点操作者列表</summary>
    [JsonPropertyName("operator_userids")]
    public string[]? OperatorUserIds { get; set; }
}

/// <summary>审批节点属性</summary>
public class WorkflowNodeAttr
{
    /// <summary>审批方式：1-或签 2-会签</summary>
    [JsonPropertyName("mode")]
    public int Mode { get; set; }

    /// <summary>节点上限时间（单位分钟）</summary>
    [JsonPropertyName("timeout")]
    public int? Timeout { get; set; }

    /// <summary>是否允许发起人向上司代交</summary>
    [JsonPropertyName("set_approver")]
    public int? SetApprover { get; set; }

    /// <summary>是否允许发起人代提交</summary>
    [JsonPropertyName("allow_reassign")]
    public int? AllowReassign { get; set; }

    /// <summary>是否发送邮件通知</summary>
    [JsonPropertyName("send_app_notify")]
    public int? SendAppNotify { get; set; }

    /// <summary>是否完成后打印</summary>
    [JsonPropertyName("finish_print")]
    public int? FinishPrint { get; set; }
}

/// <summary>节点控件信息</summary>
public class WorkflowControlInfo
{
    /// <summary>控件 id</summary>
    [JsonPropertyName("control_id")]
    public string? ControlId { get; set; }

    /// <summary>控件标题</summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <summary>控件属性</summary>
    [JsonPropertyName("property")]
    public WorkflowControlProperty? Property { get; set; }
}

/// <summary>控件属性</summary>
public class WorkflowControlProperty
{
    /// <summary>控件类型</summary>
    [JsonPropertyName("type")]
    public int Type { get; set; }

    /// <summary>控件唯一标识</summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>控件名称</summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>默认值</summary>
    [JsonPropertyName("value")]
    public string? Value { get; set; }

    /// <summary>必填：0-非必填 1-必填</summary>
    [JsonPropertyName("required")]
    public int Required { get; set; }
}
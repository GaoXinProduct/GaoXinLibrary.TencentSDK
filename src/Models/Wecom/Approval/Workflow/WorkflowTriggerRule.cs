using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval.Workflow;

/// <summary>触发条件规则</summary>
public class WorkflowTriggerRule
{
    /// <summary>触发条件类型：1-无条件 2-满足条件</summary>
    [JsonPropertyName("type")]
    public int Type { get; set; }

    /// <summary>触发条件子项</summary>
    [JsonPropertyName("cond")]
    public WorkflowTriggerCond[]? Conditions { get; set; }
}

/// <summary>触发条件子项</summary>
public class WorkflowTriggerCond
{
    /// <summary>条件控件 id</summary>
    [JsonPropertyName("control_id")]
    public string? ControlId { get; set; }

    /// <summary>条件操作符：eq-等于 neq-不等于 gt-大于 gte-大于等于 lt-小于 lte-小于等于 contain-包含 not_contain-不包含</summary>
    [JsonPropertyName("op")]
    public string? Operator { get; set; }

    /// <summary>条件值</summary>
    [JsonPropertyName("value")]
    public string[]? Values { get; set; }
}
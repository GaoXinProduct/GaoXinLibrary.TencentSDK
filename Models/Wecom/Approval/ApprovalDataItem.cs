using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

/// <summary>审批数据（旧版）</summary>
public class ApprovalDataItem
{
    /// <summary>审批名称</summary>
    [JsonPropertyName("spname")] public string? SpName { get; set; }

    /// <summary>申请人姓名</summary>
    [JsonPropertyName("apply_name")] public string? ApplyName { get; set; }

    /// <summary>申请人部门</summary>
    [JsonPropertyName("apply_org")] public string? ApplyOrg { get; set; }

    /// <summary>审批人姓名</summary>
    [JsonPropertyName("approval_name")] public string[]? ApprovalName { get; set; }

    /// <summary>抄送人姓名</summary>
    [JsonPropertyName("notify_name")] public string[]? NotifyName { get; set; }

    /// <summary>审批状态：1-审批中 2-已通过 3-已驳回 4-已撤销</summary>
    [JsonPropertyName("sp_status")] public int SpStatus { get; set; }

    /// <summary>审批单号</summary>
    [JsonPropertyName("sp_num")] public long SpNum { get; set; }

    /// <summary>抄送标识</summary>
    [JsonPropertyName("mediaids")] public string[]? MediaIds { get; set; }

    /// <summary>申请时间</summary>
    [JsonPropertyName("apply_time")] public long ApplyTime { get; set; }

    /// <summary>申请人 userid</summary>
    [JsonPropertyName("apply_user_id")] public string? ApplyUserId { get; set; }

    /// <summary>审批模板 id</summary>
    [JsonPropertyName("comm")] public ApprovalDataComm? Comm { get; set; }
}


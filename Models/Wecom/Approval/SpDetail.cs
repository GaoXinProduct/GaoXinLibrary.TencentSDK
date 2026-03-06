using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

/// <summary>审批节点详情</summary>
public class SpDetail
{
    /// <summary>分支审批人</summary>
    [JsonPropertyName("approver")] public ApprovalApplyerInfo? Approver { get; set; }

    /// <summary>审批意见</summary>
    [JsonPropertyName("speech")] public string? Speech { get; set; }

    /// <summary>分支审批人审批状态：1-审批中 2-已同意 3-已驳回 4-已转审</summary>
    [JsonPropertyName("sp_status")] public int? SpStatus { get; set; }

    /// <summary>节点审批操作时间（Unix 时间戳）</summary>
    [JsonPropertyName("sptime")] public long? SpTime { get; set; }
}


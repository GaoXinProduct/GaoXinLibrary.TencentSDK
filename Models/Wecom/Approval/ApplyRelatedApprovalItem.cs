using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

/// <summary>关联审批单</summary>
public class ApplyRelatedApprovalItem
{
    /// <summary>关联审批单的审批单号</summary>
    [JsonPropertyName("sp_no")] public string? SpNo { get; set; }
}

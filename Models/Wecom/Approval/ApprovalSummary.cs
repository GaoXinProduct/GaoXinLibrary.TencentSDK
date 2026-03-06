using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

/// <summary>审批摘要</summary>
public class ApprovalSummary
{
    /// <summary>摘要行信息</summary>
    [JsonPropertyName("summary_info")] public ApprovalText[]? SummaryInfo { get; set; }
}


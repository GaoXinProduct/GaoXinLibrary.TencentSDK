using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>获取审批申请详情请求</summary>
public class GetApprovalDetailRequest
{
    /// <summary>审批单号</summary>
    [JsonPropertyName("sp_no")] public string SpNo { get; set; } = string.Empty;
}


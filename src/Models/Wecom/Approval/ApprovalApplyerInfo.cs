using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

/// <summary>审批人信息</summary>
public sealed class ApprovalApplyerInfo
{
    /// <summary>审批人 userid</summary>
    [JsonPropertyName("userid")] public string? UserId { get; set; }
}


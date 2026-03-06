using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

/// <summary>获取审批申请详情响应</summary>
public class GetApprovalDetailResponse : WecomBaseResponse
{
    /// <summary>审批申请详情</summary>
    [JsonPropertyName("info")] public ApprovalDetailInfo? Info { get; set; }
}


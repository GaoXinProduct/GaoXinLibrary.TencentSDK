using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

/// <summary>审批人</summary>
public class ApprovalApprover
{
    /// <summary>审批节点审批方式：1-或签 2-会签</summary>
    [JsonPropertyName("attr")] public int Attr { get; set; }

    /// <summary>审批节点审批人 userid 列表</summary>
    [JsonPropertyName("userid")] public string[] UserId { get; set; } = [];
}


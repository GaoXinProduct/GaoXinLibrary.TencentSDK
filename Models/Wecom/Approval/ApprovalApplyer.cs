using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

/// <summary>申请人信息</summary>
public class ApprovalApplyer
{
    /// <summary>申请人 userid</summary>
    [JsonPropertyName("userid")] public string? UserId { get; set; }

    /// <summary>申请人所在部门 id</summary>
    [JsonPropertyName("partyid")] public string? PartyId { get; set; }
}


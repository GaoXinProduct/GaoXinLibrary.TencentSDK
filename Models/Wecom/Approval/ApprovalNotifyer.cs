using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

/// <summary>抄送人信息</summary>
public class ApprovalNotifyer
{
    /// <summary>抄送人 userid</summary>
    [JsonPropertyName("userid")] public string? UserId { get; set; }
}


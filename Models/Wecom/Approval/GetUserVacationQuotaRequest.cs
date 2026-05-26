using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

/// <summary>获取成员假期余额请求</summary>
public sealed class GetUserVacationQuotaRequest
{
    /// <summary>成员 userid</summary>
    [JsonPropertyName("userid")] public string UserId { get; set; } = string.Empty;
}


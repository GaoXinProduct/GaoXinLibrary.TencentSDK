using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

/// <summary>获取成员假期余额响应</summary>
public class GetUserVacationQuotaResponse : WecomBaseResponse
{
    /// <summary>假期列表</summary>
    [JsonPropertyName("lists")] public UserVacationQuota[]? Lists { get; set; }
}


using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>升级专员信息</summary>
public class KfUpgradeMember
{
    /// <summary>专员 userid</summary>
    [JsonPropertyName("userid")] public string UserId { get; set; } = string.Empty;

    /// <summary>推荐语</summary>
    [JsonPropertyName("wording")] public string? Wording { get; set; }
}


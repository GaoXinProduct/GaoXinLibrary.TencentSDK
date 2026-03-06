using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>升级客户群信息</summary>
public class KfUpgradeGroupChat
{
    /// <summary>客户群 chatid</summary>
    [JsonPropertyName("chatid")] public string ChatId { get; set; } = string.Empty;

    /// <summary>推荐语</summary>
    [JsonPropertyName("wording")] public string? Wording { get; set; }
}


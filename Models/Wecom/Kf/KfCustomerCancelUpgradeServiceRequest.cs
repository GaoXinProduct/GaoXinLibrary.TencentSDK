using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>为客户取消升级服务请求</summary>
public class KfCustomerCancelUpgradeServiceRequest
{
    /// <summary>客服账号 id</summary>
    [JsonPropertyName("open_kfid")] public string OpenKfId { get; set; } = string.Empty;

    /// <summary>微信客户的 external_userid</summary>
    [JsonPropertyName("external_userid")] public string ExternalUserId { get; set; } = string.Empty;
}


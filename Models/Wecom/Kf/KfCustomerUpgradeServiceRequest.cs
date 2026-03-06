using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>为客户升级为专员或客户群服务请求</summary>
public class KfCustomerUpgradeServiceRequest
{
    /// <summary>客服账号 id</summary>
    [JsonPropertyName("open_kfid")] public string OpenKfId { get; set; } = string.Empty;

    /// <summary>微信客户的 external_userid</summary>
    [JsonPropertyName("external_userid")] public string ExternalUserId { get; set; } = string.Empty;

    /// <summary>升级类型：1-专员服务 2-客户群服务</summary>
    [JsonPropertyName("type")] public int Type { get; set; }

    /// <summary>升级为专员服务（type=1 时填写）</summary>
    [JsonPropertyName("member")] public KfUpgradeMember? Member { get; set; }

    /// <summary>升级为客户群服务（type=2 时填写）</summary>
    [JsonPropertyName("groupchat")] public KfUpgradeGroupChat? GroupChat { get; set; }
}


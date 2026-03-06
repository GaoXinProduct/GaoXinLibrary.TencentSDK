using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>变更会话状态请求</summary>
public class KfServiceStateTransRequest
{
    /// <summary>客服账号 id</summary>
    [JsonPropertyName("open_kfid")] public string OpenKfId { get; set; } = string.Empty;

    /// <summary>微信客户的 external_userid</summary>
    [JsonPropertyName("external_userid")] public string ExternalUserId { get; set; } = string.Empty;

    /// <summary>变更的目标状态</summary>
    [JsonPropertyName("service_state")] public int ServiceState { get; set; }

    /// <summary>接待人员的 userid（转人工时必填）</summary>
    [JsonPropertyName("servicer_userid")] public string? ServicerUserId { get; set; }
}


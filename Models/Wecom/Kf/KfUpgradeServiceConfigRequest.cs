using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>获取配置的专员与客户群请求</summary>
public class KfUpgradeServiceConfigRequest
{
    /// <summary>客服账号 id</summary>
    [JsonPropertyName("open_kfid")] public string OpenKfId { get; set; } = string.Empty;
}


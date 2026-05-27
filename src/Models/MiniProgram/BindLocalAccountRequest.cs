using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 发起绑定请求（POST /cgi-bin/express/delivery/open/bind_local_account）
/// </summary>
public sealed class BindLocalAccountRequest
{
    /// <summary>配送公司ID</summary>
    [JsonPropertyName("delivery_id")] public required string DeliveryId { get; set; }
    /// <summary>商户侧关联账号</summary>
    [JsonPropertyName("account")] public required string Account { get; set; }
    /// <summary>商户名称</summary>
    [JsonPropertyName("merchant_name")] public string? MerchantName { get; set; }
}
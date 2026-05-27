using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 添加小费请求（POST /cgi-bin/express/delivery/open/add_tips）
/// </summary>
public sealed class AddTipsRequest
{
    /// <summary>配送公司ID</summary>
    [JsonPropertyName("delivery_id")] public required string DeliveryId { get; set; }
    /// <summary>运单号</summary>
    [JsonPropertyName("waybill_id")] public required string WaybillId { get; set; }
    /// <summary>小费金额（分）</summary>
    [JsonPropertyName("tips")] public required int Tips { get; set; }
}
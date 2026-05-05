using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 异常件退回商家确认请求（POST /cgi-bin/express/delivery/open/abnormal_confirm）
/// </summary>
public sealed class AbnormalConfirmRequest
{
    /// <summary>配送公司ID</summary>
    [JsonPropertyName("delivery_id")] public required string DeliveryId { get; set; }
    /// <summary>运单号</summary>
    [JsonPropertyName("waybill_id")] public required string WaybillId { get; set; }
    /// <summary>确认类型（1确认退回 2确认签收）</summary>
    [JsonPropertyName("confirm_type")] public required int ConfirmType { get; set; }
}
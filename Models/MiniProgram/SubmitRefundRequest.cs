using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 商家提交退款凭证请求（POST /wxa/feedback/submit_refund）
/// </summary>
public sealed class SubmitRefundRequest
{
    [JsonPropertyName("complaint_id")] public required string ComplaintId { get; set; }
    [JsonPropertyName("refund_amount")] public required int RefundAmount { get; set; }
    [JsonPropertyName("refund_reason")] public string? RefundReason { get; set; }
}

using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 查询投诉单详情请求（POST /wxa/feedback/get_order_detail）
/// </summary>
public sealed class GetOrderDetailRequest
{
    [JsonPropertyName("complaint_id")] public required string ComplaintId { get; set; }
}

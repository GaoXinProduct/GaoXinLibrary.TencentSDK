using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 商家申诉请求（POST /wxa/feedback/busi_appeal）
/// </summary>
public sealed class BusiAppealRequest
{
    [JsonPropertyName("complaint_id")] public required string ComplaintId { get; set; }
    [JsonPropertyName("appeal_reason")] public required string AppealReason { get; set; }
    [JsonPropertyName("appeal evidence")] public List<string>? Evidence { get; set; }
}

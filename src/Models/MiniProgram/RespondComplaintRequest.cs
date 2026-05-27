using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 商家回应投诉请求（POST /wxa/feedback/respond_complaint）
/// </summary>
public sealed class RespondComplaintRequest
{
    [JsonPropertyName("complaint_id")] public required string ComplaintId { get; set; }
    [JsonPropertyName("response_content")] public required string ResponseContent { get; set; }
}

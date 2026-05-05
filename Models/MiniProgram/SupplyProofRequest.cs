using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 商家补充凭证请求（POST /wxa/feedback/supply_proof）
/// </summary>
public sealed class SupplyProofRequest
{
    [JsonPropertyName("complaint_id")] public required string ComplaintId { get; set; }
    [JsonPropertyName("proof_type")] public required int ProofType { get; set; }
    [JsonPropertyName("proof_url")] public string? ProofUrl { get; set; }
}

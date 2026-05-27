using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 确认和解请求（POST /wxa/comment/confirm_compromise）
/// </summary>
public sealed class ConfirmCompromiseRequest
{
    [JsonPropertyName("comment_id")] public required string CommentId { get; set; }
}

using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 创建评论请求（POST /wxa/comment/add_reply）
/// </summary>
public sealed class AddReplyRequest
{
    [JsonPropertyName("comment_id")] public required string CommentId { get; set; }
    [JsonPropertyName("content")] public required string Content { get; set; }
}

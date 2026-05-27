using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 创建回复请求（POST /wxa/comment/add_comment_reply）
/// </summary>
public sealed class AddCommentReplyRequest
{
    [JsonPropertyName("comment_id")] public required string CommentId { get; set; }
    [JsonPropertyName("content")] public required string Content { get; set; }
}

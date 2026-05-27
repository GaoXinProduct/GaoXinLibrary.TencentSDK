using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 删除回复请求（POST /wxa/comment/delete_comment_reply）
/// </summary>
public sealed class DeleteCommentReplyRequest
{
    [JsonPropertyName("comment_id")] public required string CommentId { get; set; }
}

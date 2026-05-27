using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 删除评论请求（POST /wxa/comment/delete_reply）
/// </summary>
public sealed class DeleteReplyRequest
{
    [JsonPropertyName("comment_id")] public required string CommentId { get; set; }
}

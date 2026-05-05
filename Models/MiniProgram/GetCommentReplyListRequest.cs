using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 查询评论列表请求（POST /wxa/comment/get_comment_reply_list）
/// </summary>
public sealed class GetCommentReplyListRequest
{
    /// <summary>评价ID</summary>
    [JsonPropertyName("comment_id")] public required string CommentId { get; set; }
}

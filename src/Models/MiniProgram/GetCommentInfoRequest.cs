using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 查询评价详情请求（POST /wxa/comment/get_comment_info）
/// </summary>
public sealed class GetCommentInfoRequest
{
    [JsonPropertyName("comment_id")] public required string CommentId { get; set; }
}

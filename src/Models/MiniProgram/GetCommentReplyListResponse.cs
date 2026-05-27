using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 查询评论列表响应
/// </summary>
public sealed class GetCommentReplyListResponse : WechatBaseResponse
{
    [JsonPropertyName("reply_list")] public List<CommentReplyItem>? ReplyList { get; init; }
}

public sealed class CommentReplyItem
{
    [JsonPropertyName("reply_id")] public string? ReplyId { get; init; }
    [JsonPropertyName("content")] public string? Content { get; init; }
    [JsonPropertyName("create_time")] public long CreateTime { get; init; }
}

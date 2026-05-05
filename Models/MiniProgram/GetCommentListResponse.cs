using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 查询评价列表响应
/// </summary>
public sealed class GetCommentListResponse : WechatBaseResponse
{
    /// <summary>评价列表</summary>
    [JsonPropertyName("comment_list")] public List<CommentItem>? CommentList { get; init; }
    /// <summary>总数</summary>
    [JsonPropertyName("total")] public int Total { get; init; }
}

public sealed class CommentItem
{
    [JsonPropertyName("comment_id")] public string? CommentId { get; init; }
    [JsonPropertyName("order_id")] public string? OrderId { get; init; }
    [JsonPropertyName("star")] public int Star { get; init; }
    [JsonPropertyName("content")] public string? Content { get; init; }
    [JsonPropertyName("create_time")] public long CreateTime { get; init; }
}

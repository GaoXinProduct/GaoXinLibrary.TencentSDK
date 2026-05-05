using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 查询评价详情响应
/// </summary>
public sealed class GetCommentInfoResponse : WechatBaseResponse
{
    [JsonPropertyName("comment")] public CommentDetail? Comment { get; init; }
}

public sealed class CommentDetail
{
    [JsonPropertyName("comment_id")] public string? CommentId { get; init; }
    [JsonPropertyName("order_id")] public string? OrderId { get; init; }
    [JsonPropertyName("star")] public int Star { get; init; }
    [JsonPropertyName("content")] public string? Content { get; init; }
    [JsonPropertyName("images")] public List<string>? Images { get; init; }
    [JsonPropertyName("create_time")] public long CreateTime { get; init; }
}

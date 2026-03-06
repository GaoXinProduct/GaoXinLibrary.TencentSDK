using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>评论项</summary>
public class CommentItem
{
    [JsonPropertyName("user_comment_id")] public long UserCommentId { get; set; }
    [JsonPropertyName("openid")] public string? OpenId { get; set; }
    [JsonPropertyName("create_time")] public long CreateTime { get; set; }
    [JsonPropertyName("content")] public string? Content { get; set; }
    [JsonPropertyName("comment_type")] public int CommentType { get; set; }
    [JsonPropertyName("reply")] public CommentReply? Reply { get; set; }
}


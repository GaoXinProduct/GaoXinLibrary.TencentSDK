using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>回复评论请求（POST /cgi-bin/comment/reply/add）</summary>
public class ReplyCommentRequest
{
    [JsonPropertyName("msg_data_id")] public required long MsgDataId { get; set; }
    [JsonPropertyName("index")] public int Index { get; set; }
    [JsonPropertyName("user_comment_id")] public required long UserCommentId { get; set; }
    [JsonPropertyName("content")] public required string Content { get; set; }
}


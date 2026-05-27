using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>删除回复请求（POST /cgi-bin/comment/reply/delete）</summary>
public sealed class DeleteCommentReplyRequest
{
    [JsonPropertyName("msg_data_id")] public required long MsgDataId { get; set; }
    [JsonPropertyName("index")] public int Index { get; set; }
    [JsonPropertyName("user_comment_id")] public required long UserCommentId { get; set; }
}


using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>将评论标记/取消精选请求</summary>
public class MarkElectCommentRequest
{
    [JsonPropertyName("msg_data_id")] public required long MsgDataId { get; set; }
    [JsonPropertyName("index")] public int Index { get; set; }
    [JsonPropertyName("user_comment_id")] public required long UserCommentId { get; set; }
}


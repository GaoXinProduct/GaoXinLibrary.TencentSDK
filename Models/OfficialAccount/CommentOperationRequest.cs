using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>打开/关闭已群发文章评论请求</summary>
public class CommentOperationRequest
{
    /// <summary>群发返回的 msg_data_id</summary>
    [JsonPropertyName("msg_data_id")] public required long MsgDataId { get; set; }
    /// <summary>多图文时，用来指定第几篇图文（从 0 开始）</summary>
    [JsonPropertyName("index")] public int Index { get; set; }
}


using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>删除群发请求（POST /cgi-bin/message/mass/delete）</summary>
public class MassDeleteRequest
{
    [JsonPropertyName("msg_id")] public required long MsgId { get; set; }
    /// <summary>要删除的文章在图文消息中的位置（多图文时），第一篇编号为 1；该字段不填或填 0 会删除全部文章</summary>
    [JsonPropertyName("article_idx")] public int ArticleIdx { get; set; }
}


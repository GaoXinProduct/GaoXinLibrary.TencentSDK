using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>删除发布请求（POST /cgi-bin/freepublish/delete）</summary>
public class DeletePublishRequest
{
    [JsonPropertyName("article_id")] public required string ArticleId { get; set; }
    /// <summary>要删除的文章在图文消息中的位置（多图文时），第一篇编号为 1</summary>
    [JsonPropertyName("index")] public int Index { get; set; }
}


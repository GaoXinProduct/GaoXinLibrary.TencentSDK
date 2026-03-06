using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>通过 article_id 获取已发布文章请求（POST /cgi-bin/freepublish/getarticle）</summary>
public class GetArticleRequest
{
    [JsonPropertyName("article_id")] public required string ArticleId { get; set; }
}


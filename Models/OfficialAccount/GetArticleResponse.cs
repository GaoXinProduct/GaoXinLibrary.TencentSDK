using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>通过 article_id 获取已发布文章响应</summary>
public class GetArticleResponse : WechatBaseResponse
{
    [JsonPropertyName("news_item")] public List<DraftArticle>? NewsItem { get; set; }
}


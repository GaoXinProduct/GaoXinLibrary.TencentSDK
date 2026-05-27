using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>发布文章项</summary>
public sealed class PublishArticleItem
{
    [JsonPropertyName("idx")] public int Idx { get; set; }
    [JsonPropertyName("article_url")] public string? ArticleUrl { get; set; }
}


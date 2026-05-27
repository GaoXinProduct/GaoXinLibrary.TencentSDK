using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>草稿内容</summary>
public sealed class DraftContent
{
    [JsonPropertyName("news_item")] public List<DraftArticle>? NewsItem { get; set; }
}


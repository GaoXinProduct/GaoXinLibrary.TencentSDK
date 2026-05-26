using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>发布文章详情</summary>
public sealed class PublishArticleDetail
{
    [JsonPropertyName("count")] public int Count { get; set; }
    [JsonPropertyName("item")] public List<PublishArticleItem>? Item { get; set; }
}


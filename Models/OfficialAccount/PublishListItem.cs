using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>发布列表项</summary>
public class PublishListItem
{
    [JsonPropertyName("article_id")] public string? ArticleId { get; set; }
    [JsonPropertyName("content")] public DraftContent? Content { get; set; }
    [JsonPropertyName("update_time")] public long UpdateTime { get; set; }
}


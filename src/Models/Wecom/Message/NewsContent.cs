using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Message;

public sealed class NewsContent
{
    [JsonPropertyName("articles")] public NewsArticle[] Articles { get; set; } = [];
}


using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Message;

public sealed class MpNewsContent
{
    [JsonPropertyName("articles")] public MpNewsArticle[] Articles { get; set; } = [];
}


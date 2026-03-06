using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Message;

public class MpNewsContent
{
    [JsonPropertyName("articles")] public MpNewsArticle[] Articles { get; set; } = [];
}


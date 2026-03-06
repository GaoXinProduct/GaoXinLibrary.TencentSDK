using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>图文链接内容</summary>
public class CustomLinkContent
{
    [JsonPropertyName("title")] public required string Title { get; set; }
    [JsonPropertyName("description")] public required string Description { get; set; }
    [JsonPropertyName("url")] public required string Url { get; set; }
    [JsonPropertyName("thumb_url")] public required string ThumbUrl { get; set; }
}


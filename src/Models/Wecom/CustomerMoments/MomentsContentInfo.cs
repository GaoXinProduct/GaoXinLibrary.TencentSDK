using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CustomerMoments;

/// <summary>
/// 朋友圈内容信息
/// </summary>
public record MomentsContentInfo
{
    /// <summary>文本内容</summary>
    [JsonPropertyName("text")]
    public MomentsTextContent? Text { get; set; }

    /// <summary>图片内容列表</summary>
    [JsonPropertyName("image")]
    public MomentsImageContent[]? Image { get; set; }

    /// <summary>视频内容</summary>
    [JsonPropertyName("video")]
    public MomentsVideoContent? Video { get; set; }

    /// <summary>链接内容</summary>
    [JsonPropertyName("link")]
    public MomentsLinkContent? Link { get; set; }
}
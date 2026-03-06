using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Message;

/// <summary>卡片图片样式</summary>
public class TemplateCardImage
{
    /// <summary>图片的 URL</summary>
    [JsonPropertyName("url")] public string Url { get; set; } = string.Empty;

    /// <summary>图片的宽高比，宽高比要小于 2.25，大于 1.3，不填该参数默认 1.3</summary>
    [JsonPropertyName("aspect_ratio")] public double? AspectRatio { get; set; }
}


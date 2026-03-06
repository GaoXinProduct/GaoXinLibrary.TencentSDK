using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>小程序卡片内容</summary>
public class CustomMiniProgramContent
{
    [JsonPropertyName("title")] public required string Title { get; set; }
    [JsonPropertyName("pagepath")] public required string PagePath { get; set; }
    [JsonPropertyName("thumb_media_id")] public required string ThumbMediaId { get; set; }
}


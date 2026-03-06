using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>小程序卡片</summary>
public class CustomMsgMiniProgram
{
    [JsonPropertyName("title")] public required string Title { get; set; }
    [JsonPropertyName("appid")] public required string AppId { get; set; }
    [JsonPropertyName("pagepath")] public required string PagePath { get; set; }
    [JsonPropertyName("thumb_media_id")] public required string ThumbMediaId { get; set; }
}


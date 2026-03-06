using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>小程序消息内容</summary>
public class KfMsgMiniProgram
{
    /// <summary>标题</summary>
    [JsonPropertyName("title")] public string? Title { get; set; }

    /// <summary>小程序 appid</summary>
    [JsonPropertyName("appid")] public string? AppId { get; set; }

    /// <summary>小程序 pagepath</summary>
    [JsonPropertyName("pagepath")] public string? PagePath { get; set; }

    /// <summary>缩略图 media_id</summary>
    [JsonPropertyName("thumb_media_id")] public string? ThumbMediaId { get; set; }
}


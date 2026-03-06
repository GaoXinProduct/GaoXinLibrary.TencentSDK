using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 获取素材总数响应（GET /cgi-bin/material/get_materialcount）
/// </summary>
public class MaterialCountResponse : WechatBaseResponse
{
    /// <summary>语音素材数量</summary>
    [JsonPropertyName("voice_count")] public int VoiceCount { get; set; }

    /// <summary>视频素材数量</summary>
    [JsonPropertyName("video_count")] public int VideoCount { get; set; }

    /// <summary>图片素材数量</summary>
    [JsonPropertyName("image_count")] public int ImageCount { get; set; }

    /// <summary>图文素材数量</summary>
    [JsonPropertyName("news_count")] public int NewsCount { get; set; }
}


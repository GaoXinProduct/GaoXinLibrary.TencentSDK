using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>
/// 音视频内容安全异步检测请求（POST /wxa/media_check_async）
/// </summary>
public class MediaCheckAsyncRequest
{
    /// <summary>要检测的图片或音频的 URL（支持图片/音频）</summary>
    [JsonPropertyName("media_url")] public required string MediaUrl { get; set; }

    /// <summary>媒体类型（1 音频；2 图片）</summary>
    [JsonPropertyName("media_type")] public int MediaType { get; set; }

    /// <summary>接口版本号，固定为 2</summary>
    [JsonPropertyName("version")] public int Version { get; set; } = 2;

    /// <summary>场景值</summary>
    [JsonPropertyName("scene")] public int Scene { get; set; } = 1;

    /// <summary>用户的 OpenId</summary>
    [JsonPropertyName("openid")] public required string OpenId { get; set; }
}


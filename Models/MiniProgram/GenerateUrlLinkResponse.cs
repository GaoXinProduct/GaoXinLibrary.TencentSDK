using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>生成 URL Link 响应</summary>
public class GenerateUrlLinkResponse : WechatBaseResponse
{
    /// <summary>生成的 URL Link</summary>
    [JsonPropertyName("url_link")] public string? UrlLink { get; set; }
}


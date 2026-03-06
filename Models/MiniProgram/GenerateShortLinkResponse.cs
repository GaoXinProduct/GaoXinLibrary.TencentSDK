using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>生成 Short Link 响应</summary>
public class GenerateShortLinkResponse : WechatBaseResponse
{
    /// <summary>生成的 Short Link</summary>
    [JsonPropertyName("link")] public string? Link { get; set; }
}


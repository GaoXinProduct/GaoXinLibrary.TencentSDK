using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>生成 URL Scheme 响应</summary>
public class GenerateSchemeResponse : WechatBaseResponse
{
    /// <summary>生成的 URL Scheme</summary>
    [JsonPropertyName("openlink")] public string? OpenLink { get; set; }
}


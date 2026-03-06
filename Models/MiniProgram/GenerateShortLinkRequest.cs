using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>
/// 生成 Short Link 请求（POST /wxa/genwxashortlink）
/// </summary>
public class GenerateShortLinkRequest
{
    /// <summary>通过 Short Link 进入的小程序页面路径（须是已发布的小程序存在的页面）</summary>
    [JsonPropertyName("page_url")] public required string PageUrl { get; set; }

    /// <summary>页面标题（不超过 32 字符）</summary>
    [JsonPropertyName("page_title")] public string? PageTitle { get; set; }

    /// <summary>是否永久有效（默认 false，有效期 30 天）</summary>
    [JsonPropertyName("is_permanent")] public bool? IsPermanent { get; set; }
}


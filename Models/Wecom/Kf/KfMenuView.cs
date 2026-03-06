using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>菜单-链接</summary>
public class KfMenuView
{
    /// <summary>链接 URL</summary>
    [JsonPropertyName("url")] public string? Url { get; set; }

    /// <summary>链接内容</summary>
    [JsonPropertyName("content")] public string? Content { get; set; }
}


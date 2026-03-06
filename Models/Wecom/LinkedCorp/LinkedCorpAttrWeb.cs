using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.LinkedCorp;

/// <summary>网页属性值</summary>
public class LinkedCorpAttrWeb
{
    /// <summary>网页标题</summary>
    [JsonPropertyName("title")] public string? Title { get; set; }

    /// <summary>网页 URL</summary>
    [JsonPropertyName("url")] public string? Url { get; set; }
}


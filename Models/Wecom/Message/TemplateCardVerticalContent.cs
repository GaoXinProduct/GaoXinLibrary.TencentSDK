using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Message;

/// <summary>竖向内容</summary>
public class TemplateCardVerticalContent
{
    /// <summary>竖向内容的标题</summary>
    [JsonPropertyName("title")] public string Title { get; set; } = string.Empty;

    /// <summary>竖向内容的描述</summary>
    [JsonPropertyName("desc")] public string? Desc { get; set; }
}


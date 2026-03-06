using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Message;

/// <summary>关键数据样式</summary>
public class TemplateCardEmphasisContent
{
    /// <summary>关键数据标题（建议不超过14个字）</summary>
    [JsonPropertyName("title")] public string? Title { get; set; }

    /// <summary>关键数据描述（建议不超过22个字）</summary>
    [JsonPropertyName("desc")] public string? Desc { get; set; }
}


using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Message;

/// <summary>模版卡片一级标题</summary>
public class TemplateCardMainTitle
{
    /// <summary>一级标题（建议不超过26个字，不超过2行）</summary>
    [JsonPropertyName("title")] public string? Title { get; set; }

    /// <summary>标题辅助信息（建议不超过30个字，不超过1行）</summary>
    [JsonPropertyName("desc")] public string? Desc { get; set; }
}


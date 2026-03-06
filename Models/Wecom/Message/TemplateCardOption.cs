using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Message;

/// <summary>选项</summary>
public class TemplateCardOption
{
    /// <summary>选项 ID</summary>
    [JsonPropertyName("id")] public string Id { get; set; } = string.Empty;

    /// <summary>选项文案</summary>
    [JsonPropertyName("text")] public string Text { get; set; } = string.Empty;
}


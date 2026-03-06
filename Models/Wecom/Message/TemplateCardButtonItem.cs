using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Message;

/// <summary>按钮交互型 — 按钮项</summary>
public class TemplateCardButtonItem
{
    /// <summary>按钮文案（建议不超过10个字）</summary>
    [JsonPropertyName("text")] public string Text { get; set; } = string.Empty;

    /// <summary>按钮样式：1=常规样式, 2=强调样式（默认1）</summary>
    [JsonPropertyName("style")] public int? Style { get; set; }

    /// <summary>按钮 key 值（点击后回调用）</summary>
    [JsonPropertyName("key")] public string Key { get; set; } = string.Empty;
}


using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Message;

/// <summary>提交按钮样式</summary>
public class TemplateCardSubmitButton
{
    /// <summary>按钮文案（建议不超过10个字，不填默认为"提交"）</summary>
    [JsonPropertyName("text")] public string Text { get; set; } = string.Empty;

    /// <summary>提交按钮的 key（回调用）</summary>
    [JsonPropertyName("key")] public string Key { get; set; } = string.Empty;
}


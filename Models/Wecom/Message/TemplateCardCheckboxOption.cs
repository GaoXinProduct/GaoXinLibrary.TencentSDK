using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Message;

/// <summary>投票选项</summary>
public class TemplateCardCheckboxOption
{
    /// <summary>选项 ID</summary>
    [JsonPropertyName("id")] public string Id { get; set; } = string.Empty;

    /// <summary>选项文案（建议不超过17个字）</summary>
    [JsonPropertyName("text")] public string Text { get; set; } = string.Empty;

    /// <summary>是否默认选中</summary>
    [JsonPropertyName("is_checked")] public bool IsChecked { get; set; }
}


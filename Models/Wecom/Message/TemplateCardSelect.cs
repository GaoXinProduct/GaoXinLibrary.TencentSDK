using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Message;

/// <summary>多项选择列表项</summary>
public class TemplateCardSelect
{
    /// <summary>下拉式的选择器的 key（回调用）</summary>
    [JsonPropertyName("question_key")] public string QuestionKey { get; set; } = string.Empty;

    /// <summary>下拉式的选择器的标题（建议不超过26个字）</summary>
    [JsonPropertyName("title")] public string? Title { get; set; }

    /// <summary>默认选中的 id</summary>
    [JsonPropertyName("selected_id")] public string? SelectedId { get; set; }

    /// <summary>选项列表（最多20个）</summary>
    [JsonPropertyName("option_list")] public TemplateCardOption[]? OptionList { get; set; }
}


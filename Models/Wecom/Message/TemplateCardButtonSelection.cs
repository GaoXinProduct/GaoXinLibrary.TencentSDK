using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Message;

/// <summary>按钮交互型 — 下拉式按钮</summary>
public class TemplateCardButtonSelection
{
    /// <summary>下拉式的选择器的 key（回调用）</summary>
    [JsonPropertyName("question_key")] public string QuestionKey { get; set; } = string.Empty;

    /// <summary>下拉式的选择器的标题</summary>
    [JsonPropertyName("title")] public string? Title { get; set; }

    /// <summary>选项列表（最多20个）</summary>
    [JsonPropertyName("option_list")] public TemplateCardOption[]? OptionList { get; set; }

    /// <summary>默认选中的 id，不填则默认不选中任何选项</summary>
    [JsonPropertyName("selected_id")] public string? SelectedId { get; set; }
}


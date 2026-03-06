using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Message;

/// <summary>投票交互型 — 选择题</summary>
public class TemplateCardCheckbox
{
    /// <summary>选择题 key（回调用）</summary>
    [JsonPropertyName("question_key")] public string QuestionKey { get; set; } = string.Empty;

    /// <summary>选择题模式：0=单选, 1=多选</summary>
    [JsonPropertyName("mode")] public int Mode { get; set; }

    /// <summary>选项列表（最多20个）</summary>
    [JsonPropertyName("option_list")] public TemplateCardCheckboxOption[]? OptionList { get; set; }
}


using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CollectForm;

/// <summary>收集表问题</summary>
public class CollectQuestion
{
    /// <summary>问题ID</summary>
    [JsonPropertyName("question_id")] public int QuestionId { get; set; }

    /// <summary>问题标题</summary>
    [JsonPropertyName("title")] public string? Title { get; set; }

    /// <summary>问题类型，1-单选，2-多选，3-填空</summary>
    [JsonPropertyName("question_type")] public int QuestionType { get; set; }

    /// <summary>是否必填</summary>
    [JsonPropertyName("is_required")] public bool IsRequired { get; set; }

    /// <summary>选项列表（单选/多选时）</summary>
    [JsonPropertyName("option_list")] public CollectOption[]? OptionList { get; set; }
}

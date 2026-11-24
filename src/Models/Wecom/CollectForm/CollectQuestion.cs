
namespace GaoXinLibrary.TencentSDK.Wecom.Models.CollectForm;

/// <summary>收集表问题</summary>
public sealed class CollectQuestion
{
    /// <summary>问题ID</summary>
    [JsonPropertyName("question_id")] public int QuestionId { get; set; }

    /// <summary>问题标题</summary>
    [JsonPropertyName("title")] public string? Title { get; set; }

    /// <summary>从 1 开始的问题序号。未指定时按列表顺序填写。</summary>
    [JsonPropertyName("pos")] public int Position { get; set; }

    /// <summary>问题状态，1 为正常，2 为已删除。</summary>
    [JsonPropertyName("status")] public int Status { get; set; } = 1;

    /// <summary>官方问题类型，例如 1 为文本，2 为单选，3 为多选。</summary>
    [JsonPropertyName("reply_type")] public int ReplyType { get; set; }

    /// <summary>旧版问题类型，1 为单选，2 为多选，3 为填空。</summary>
    [JsonIgnore]
    public int QuestionType
    {
        get => ReplyType switch { 2 => 1, 3 => 2, 1 => 3, _ => ReplyType };
        set => ReplyType = value switch { 1 => 2, 2 => 3, 3 => 1, _ => value };
    }

    /// <summary>是否必填</summary>
    [JsonPropertyName("must_reply")] public bool IsRequired { get; set; }

    /// <summary>问题备注。</summary>
    [JsonPropertyName("note")] public string? Note { get; set; }

    /// <summary>输入提示。</summary>
    [JsonPropertyName("placeholder")] public string? Placeholder { get; set; }

    /// <summary>选项列表（单选/多选时）</summary>
    [JsonPropertyName("option_item")] public CollectOption[]? OptionList { get; set; }

    /// <summary>按问题类型填写的额外设置，例如文本题的 text_setting。</summary>
    [JsonPropertyName("question_extend_setting")] public JsonElement? ExtendedSettings { get; set; }

    internal CollectQuestion WithDefaultPosition(int position)
    {
        if (Position != 0)
            return this;
        var question = (CollectQuestion)MemberwiseClone();
        question.Position = position;
        return question;
    }
}

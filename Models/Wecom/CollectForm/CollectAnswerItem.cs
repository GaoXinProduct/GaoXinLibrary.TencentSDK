using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CollectForm;

/// <summary>收集表答案项</summary>
public class CollectAnswerItem
{
    /// <summary>问题ID</summary>
    [JsonPropertyName("question_id")] public int QuestionId { get; set; }

    /// <summary>填写的文本答案</summary>
    [JsonPropertyName("text_answer")] public string? TextAnswer { get; set; }

    /// <summary>选中的选项ID列表</summary>
    [JsonPropertyName("option_answer")] public int[]? OptionAnswer { get; set; }
}

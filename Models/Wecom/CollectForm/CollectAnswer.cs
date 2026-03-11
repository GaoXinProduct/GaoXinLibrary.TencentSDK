using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CollectForm;

/// <summary>收集表答案</summary>
public class CollectAnswer
{
    /// <summary>提交者userid</summary>
    [JsonPropertyName("userid")] public string? UserId { get; set; }

    /// <summary>提交时间（Unix时间戳）</summary>
    [JsonPropertyName("submit_time")] public long SubmitTime { get; set; }

    /// <summary>答案列表</summary>
    [JsonPropertyName("answer_list")] public CollectAnswerItem[]? AnswerList { get; set; }
}

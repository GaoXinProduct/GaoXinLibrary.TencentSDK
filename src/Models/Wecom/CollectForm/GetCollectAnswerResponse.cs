using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CollectForm;

/// <summary>获取收集表答案响应。</summary>
public class GetCollectAnswerResponse : WecomBaseResponse
{
    /// <summary>答案数据。</summary>
    [JsonPropertyName("answer")] public CollectFormAnswers? Answer { get; set; }

    /// <summary>答案列表。</summary>
    [JsonIgnore]
    public CollectAnswer[]? AnswerList
    {
        get => Answer?.AnswerList;
        set => Answer = value is null ? null : new() { AnswerList = value };
    }

    /// <summary>旧版分页字段。官方答案查询按 ID 返回结果。</summary>
    [JsonPropertyName("has_more")] public bool HasMore { get; set; }
    /// <summary>旧版分页字段。请通过统计接口的游标读取更多答案 ID。</summary>
    [JsonPropertyName("next_cursor")] public string? NextCursor { get; set; }
}

/// <summary>收集表答案数据。</summary>
public sealed class CollectFormAnswers
{
    /// <summary>答案列表。</summary>
    [JsonPropertyName("answer_list")] public CollectAnswer[]? AnswerList { get; set; }
}

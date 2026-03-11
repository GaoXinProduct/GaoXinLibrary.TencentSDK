using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CollectForm;

/// <summary>获取收集表答案响应</summary>
public class GetCollectAnswerResponse : WecomBaseResponse
{
    /// <summary>答案列表</summary>
    [JsonPropertyName("answer_list")] public CollectAnswer[]? AnswerList { get; set; }

    /// <summary>是否还有更多</summary>
    [JsonPropertyName("has_more")] public bool HasMore { get; set; }

    /// <summary>分页游标</summary>
    [JsonPropertyName("next_cursor")] public string? NextCursor { get; set; }
}

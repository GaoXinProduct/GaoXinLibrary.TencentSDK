using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CollectForm;

/// <summary>收集表信息</summary>
public class CollectFormInfo
{
    /// <summary>收集表ID</summary>
    [JsonPropertyName("formid")] public string? FormId { get; set; }

    /// <summary>收集表标题</summary>
    [JsonPropertyName("title")] public string? Title { get; set; }

    /// <summary>收集表描述</summary>
    [JsonPropertyName("description")] public string? Description { get; set; }

    /// <summary>创建者userid</summary>
    [JsonPropertyName("creator")] public string? Creator { get; set; }

    /// <summary>创建时间（Unix时间戳）</summary>
    [JsonPropertyName("create_time")] public long CreateTime { get; set; }

    /// <summary>截止时间（Unix时间戳，0表示不限制）</summary>
    [JsonPropertyName("end_time")] public long EndTime { get; set; }

    /// <summary>收集表状态，1-进行中，2-已结束</summary>
    [JsonPropertyName("status")] public int Status { get; set; }

    /// <summary>已提交数量</summary>
    [JsonPropertyName("answered_count")] public int AnsweredCount { get; set; }

    /// <summary>收集表URL</summary>
    [JsonPropertyName("form_url")] public string? FormUrl { get; set; }

    /// <summary>问题列表</summary>
    [JsonPropertyName("question_list")] public CollectQuestion[]? QuestionList { get; set; }
}

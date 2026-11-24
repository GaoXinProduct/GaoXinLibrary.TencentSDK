
namespace GaoXinLibrary.TencentSDK.Wecom.Models.CollectForm;

/// <summary>收集表信息</summary>
public sealed class CollectFormInfo
{
    /// <summary>收集表ID</summary>
    [JsonPropertyName("formid")] public string? FormId { get; set; }

    /// <summary>收集表标题</summary>
    [JsonPropertyName("form_title")] public string? Title { get; set; }

    /// <summary>收集表描述</summary>
    [JsonPropertyName("form_desc")] public string? Description { get; set; }

    /// <summary>表头背景图 URL。</summary>
    [JsonPropertyName("form_header")] public string? Header { get; set; }

    /// <summary>收集表的问题。</summary>
    [JsonPropertyName("form_question")] public CollectFormQuestions? Questions { get; set; }

    /// <summary>填写和定时设置。</summary>
    [JsonPropertyName("form_setting")] public CollectFormSettings? Settings { get; set; }

    /// <summary>用于查询统计和答案的收集表周期 ID。</summary>
    [JsonPropertyName("repeated_id")] public string[]? RepeatedIds { get; set; }

    /// <summary>创建者userid</summary>
    [JsonPropertyName("creator")] public string? Creator { get; set; }

    /// <summary>创建时间（Unix时间戳）</summary>
    [JsonPropertyName("create_time")] public long CreateTime { get; set; }

    /// <summary>截止时间（Unix时间戳，0表示不限制）</summary>
    [JsonIgnore]
    public long EndTime
    {
        get => Settings?.TimedFinish ?? 0;
        set
        {
            var timedFinish = checked((uint)value);
            (Settings ??= new()).TimedFinish = timedFinish;
        }
    }

    /// <summary>收集表状态，1-进行中，2-已结束</summary>
    [JsonPropertyName("status")] public int Status { get; set; }

    /// <summary>已提交数量</summary>
    [JsonPropertyName("answered_count")] public int AnsweredCount { get; set; }

    /// <summary>收集表URL</summary>
    [JsonPropertyName("form_url")] public string? FormUrl { get; set; }

    /// <summary>问题列表</summary>
    [JsonIgnore]
    public CollectQuestion[]? QuestionList
    {
        get => Questions?.Items;
        set => Questions = value is null ? null : new() { Items = value };
    }
}

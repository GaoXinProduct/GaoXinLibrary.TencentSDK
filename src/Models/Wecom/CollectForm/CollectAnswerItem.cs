namespace GaoXinLibrary.TencentSDK.Wecom.Models.CollectForm;

/// <summary>收集表答案项。</summary>
public sealed class CollectAnswerItem
{
    /// <summary>旧版问题 ID。完整的无符号值请使用 <see cref="QuestionIdentifier"/>。</summary>
    [JsonIgnore]
    public int QuestionId
    {
        get => checked((int)QuestionIdentifier);
        set => QuestionIdentifier = checked((ulong)value);
    }

    /// <summary>问题 ID。</summary>
    [JsonPropertyName("question_id")] public ulong QuestionIdentifier { get; set; }
    /// <summary>填写的文本答案。</summary>
    [JsonPropertyName("text_reply")] public string? TextAnswer { get; set; }

    /// <summary>旧版选项 ID 列表。完整的无符号值请使用 <see cref="OptionIds"/>。</summary>
    [JsonIgnore]
    public int[]? OptionAnswer
    {
        get => OptionIds?.Select(static id => checked((int)id)).ToArray();
        set => OptionIds = value?.Select(static id => checked((uint)id)).ToArray();
    }

    /// <summary>选中的选项 ID 列表。</summary>
    [JsonPropertyName("option_reply")] public uint[]? OptionIds { get; set; }
    /// <summary>“其他”选项的明细。</summary>
    [JsonPropertyName("option_extend_reply")] public CollectAnswerOptionReply[]? ExtendedOptionReplies { get; set; }
    /// <summary>文件名和文件 ID 列表。</summary>
    [JsonPropertyName("file_extend_reply")] public CollectAnswerFileReply[]? FileReplies { get; set; }
    /// <summary>部门题回答。</summary>
    [JsonPropertyName("department_reply")] public CollectAnswerSelection<CollectAnswerDepartment>? DepartmentReply { get; set; }
    /// <summary>成员题回答。</summary>
    [JsonPropertyName("member_reply")] public CollectAnswerSelection<CollectAnswerMember>? MemberReply { get; set; }
    /// <summary>时长题回答。</summary>
    [JsonPropertyName("duration_reply")] public CollectAnswerDuration? DurationReply { get; set; }
}

/// <summary>文字补充选项。</summary>
public sealed class CollectAnswerOptionReply
{
    /// <summary>选项 ID。</summary>
    [JsonPropertyName("option_reply")] public uint OptionId { get; set; }
    /// <summary>填写的文字。</summary>
    [JsonPropertyName("extend_text")] public string? Text { get; set; }
}

/// <summary>提交的文件。</summary>
public sealed class CollectAnswerFileReply
{
    /// <summary>文件名。</summary>
    [JsonPropertyName("name")] public string? Name { get; set; }
    /// <summary>文件 ID。</summary>
    [JsonPropertyName("fileid")] public string? FileId { get; set; }
}

/// <summary>部门题或成员题的选择列表。</summary>
public sealed class CollectAnswerSelection<T>
{
    /// <summary>已选择项目。</summary>
    [JsonPropertyName("list")] public T[]? Items { get; set; }
}

/// <summary>选中的部门。</summary>
public sealed class CollectAnswerDepartment
{
    /// <summary>部门 ID。</summary>
    [JsonPropertyName("department_id")] public ulong DepartmentId { get; set; }
}

/// <summary>选中的成员。</summary>
public sealed class CollectAnswerMember
{
    /// <summary>企业成员 userid。</summary>
    [JsonPropertyName("userid")] public string? UserId { get; set; }
}

/// <summary>填写的时间区间和时长。</summary>
public sealed class CollectAnswerDuration
{
    /// <summary>起始 Unix 时间戳。</summary>
    [JsonPropertyName("begin_time")] public uint BeginTime { get; set; }
    /// <summary>结束 Unix 时间戳。</summary>
    [JsonPropertyName("end_time")] public uint EndTime { get; set; }
    /// <summary>时间单位，1 为日，2 为小时。</summary>
    [JsonPropertyName("time_scale")] public uint TimeScale { get; set; }
    /// <summary>一天对应的小时数。</summary>
    [JsonPropertyName("day_range")] public uint? DayRange { get; set; }
    /// <summary>天数。</summary>
    [JsonPropertyName("days")] public double? Days { get; set; }
    /// <summary>小时数。</summary>
    [JsonPropertyName("hours")] public double? Hours { get; set; }
}

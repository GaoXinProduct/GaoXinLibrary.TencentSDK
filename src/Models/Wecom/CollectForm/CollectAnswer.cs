namespace GaoXinLibrary.TencentSDK.Wecom.Models.CollectForm;

/// <summary>收集表答案。</summary>
public sealed class CollectAnswer
{
    /// <summary>答案 ID。</summary>
    [JsonPropertyName("answer_id")] public ulong AnswerId { get; set; }
    /// <summary>提交者 userid。</summary>
    [JsonPropertyName("userid")] public string? UserId { get; set; }
    /// <summary>提交时间（Unix 时间戳）。</summary>
    [JsonPropertyName("ctime")] public long SubmitTime { get; set; }
    /// <summary>修改时间（Unix 时间戳）。</summary>
    [JsonPropertyName("mtime")] public ulong ModifiedTime { get; set; }
    /// <summary>用户姓名。</summary>
    [JsonPropertyName("user_name")] public string? UserName { get; set; }
    /// <summary>外部用户临时 ID。</summary>
    [JsonPropertyName("tmp_external_userid")] public string? TemporaryExternalUserId { get; set; }
    /// <summary>答案状态，1 为正常，3 为已移除或删除。</summary>
    [JsonPropertyName("answer_status")] public uint AnswerStatus { get; set; }
    /// <summary>各问题的回答。</summary>
    [JsonPropertyName("reply")] public CollectFormReply? Reply { get; set; }

    /// <summary>答案列表。</summary>
    [JsonIgnore]
    public CollectAnswerItem[]? AnswerList
    {
        get => Reply?.Items;
        set => Reply = value is null ? null : new() { Items = value };
    }
}

/// <summary>一份答案中各问题的回复。</summary>
public sealed class CollectFormReply
{
    /// <summary>各问题的回复列表。</summary>
    [JsonPropertyName("items")] public CollectAnswerItem[]? Items { get; set; }
}

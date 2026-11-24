using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CollectForm;

/// <summary>获取收集表统计信息响应。</summary>
public class GetCollectFormStatResponse : WecomBaseResponse
{
    /// <summary>旧版收集表 ID 字段。</summary>
    [JsonPropertyName("formid")] public string? FormId { get; set; }
    /// <summary>旧版收集表标题字段。</summary>
    [JsonPropertyName("title")] public string? Title { get; set; }
    /// <summary>旧版收集表状态字段。</summary>
    [JsonPropertyName("status")] public int Status { get; set; }
    /// <summary>已提交数量。大量记录时请使用 <see cref="FillCount"/>。</summary>
    [JsonIgnore]
    public int AnsweredCount { get => checked((int)FillCount); set => FillCount = checked((ulong)value); }
    /// <summary>旧版已查看数量字段。</summary>
    [JsonPropertyName("viewed_count")] public int ViewedCount { get; set; }

    /// <summary>已填写次数。</summary>
    [JsonPropertyName("fill_cnt")] public ulong FillCount { get; set; }
    /// <summary>已填写人数。</summary>
    [JsonPropertyName("fill_user_cnt")] public ulong FilledUserCount { get; set; }
    /// <summary>未填写人数。</summary>
    [JsonPropertyName("unfill_user_cnt")] public ulong UnfilledUserCount { get; set; }
    /// <summary>已填写成员列表。</summary>
    [JsonPropertyName("submit_users")] public CollectFormSubmission[]? SubmittedUsers { get; set; }
    /// <summary>未填写成员列表。</summary>
    [JsonPropertyName("unfill_users")] public CollectFormRespondent[]? UnsubmittedUsers { get; set; }
    /// <summary>是否还有更多数据。</summary>
    [JsonPropertyName("has_more")] public bool HasMore { get; set; }
    /// <summary>下一页的游标。</summary>
    [JsonPropertyName("cursor")] public ulong? Cursor { get; set; }
}

/// <summary>收集表填写成员。</summary>
public class CollectFormRespondent
{
    /// <summary>企业成员 userid。匿名填写时可能缺省。</summary>
    [JsonPropertyName("userid")] public string? UserId { get; set; }
    /// <summary>成员姓名。</summary>
    [JsonPropertyName("user_name")] public string? UserName { get; set; }
}

/// <summary>收集表提交记录。</summary>
public sealed class CollectFormSubmission : CollectFormRespondent
{
    /// <summary>外部用户临时 ID。</summary>
    [JsonPropertyName("tmp_external_userid")] public string? TemporaryExternalUserId { get; set; }
    /// <summary>提交时间。</summary>
    [JsonPropertyName("submit_time")] public ulong SubmitTime { get; set; }
    /// <summary>用于获取具体答案的 ID。</summary>
    [JsonPropertyName("answer_id")] public ulong AnswerId { get; set; }
}

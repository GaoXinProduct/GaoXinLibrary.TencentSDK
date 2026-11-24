namespace GaoXinLibrary.TencentSDK.Wecom.Models.CollectForm;

/// <summary>获取收集表统计信息请求。</summary>
public class GetCollectFormStatRequest
{
    /// <summary>旧版字段。请使用 <see cref="RepeatedId"/>。</summary>
    [Obsolete("统计接口要求收集表周期 ID，请使用 RepeatedId。")]
    [JsonIgnore]
    public string FormId { get; set; } = string.Empty;

    /// <summary>收集表周期 ID，由读取收集表接口返回。</summary>
    [JsonPropertyName("repeated_id")] public string RepeatedId { get; set; } = string.Empty;
    /// <summary>要读取的统计信息。</summary>
    [JsonPropertyName("req_type")]
    public CollectFormStatisticType RequestType { get; set; } = CollectFormStatisticType.Counts;
    /// <summary>查询已提交成员时的起始 Unix 时间戳。</summary>
    [JsonPropertyName("start_time")] public ulong? StartTime { get; set; }
    /// <summary>查询已提交成员时的结束 Unix 时间戳。</summary>
    [JsonPropertyName("end_time")] public ulong? EndTime { get; set; }
    /// <summary>分页大小，最大 10000。</summary>
    [JsonPropertyName("limit")] public ulong? Limit { get; set; }
    /// <summary>上一页返回的游标。</summary>
    [JsonPropertyName("cursor")] public ulong? Cursor { get; set; }
}

/// <summary>收集表统计查询类型。</summary>
public enum CollectFormStatisticType
{
    /// <summary>仅获取填写统计。</summary>
    Counts = 1,
    /// <summary>获取已提交成员及答案 ID。</summary>
    Submitted = 2,
    /// <summary>获取未提交成员。</summary>
    Unsubmitted = 3
}

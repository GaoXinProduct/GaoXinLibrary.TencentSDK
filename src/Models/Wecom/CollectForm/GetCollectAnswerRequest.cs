namespace GaoXinLibrary.TencentSDK.Wecom.Models.CollectForm;

/// <summary>获取收集表答案请求。</summary>
public class GetCollectAnswerRequest
{
    /// <summary>旧版字段。收集表 ID 与周期 ID 不同。</summary>
    [Obsolete("读取答案需要收集表周期 ID，请使用 RepeatedId。")]
    [JsonIgnore]
    public string FormId { get; set; } = string.Empty;

    /// <summary>旧版字段。请通过统计接口查询可用答案的分页信息。</summary>
    [Obsolete("请使用统计接口分页获取 AnswerIds。")]
    [JsonIgnore]
    public string Cursor { get; set; } = string.Empty;

    /// <summary>旧版字段。每次最多可传入 100 个答案 ID。</summary>
    [Obsolete("请传入最多 100 个 AnswerIds。")]
    [JsonIgnore]
    public int Limit { get; set; } = 100;

    /// <summary>收集表周期 ID。</summary>
    [JsonPropertyName("repeated_id")] public string RepeatedId { get; set; } = string.Empty;
    /// <summary>从统计接口获取的答案 ID，最多 100 个。</summary>
    [JsonPropertyName("answer_ids")] public ulong[] AnswerIds { get; set; } = [];
}

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Email;

/// <summary>分页查询应用收件箱。</summary>
public sealed class GetMailListRequest
{
    /// <summary>开始 Unix 时间戳。</summary>
    [JsonPropertyName("begin_time")] public uint BeginTime { get; set; }
    /// <summary>结束 Unix 时间戳。</summary>
    [JsonPropertyName("end_time")] public uint EndTime { get; set; }
    /// <summary>前一页返回的游标。首页不填。</summary>
    [JsonPropertyName("cursor")] public string? Cursor { get; set; }
    /// <summary>每页邮件数，默认 100，最大 1000。</summary>
    [JsonPropertyName("limit")] public uint? Limit { get; set; }
}

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Security;

/// <summary>文件操作记录查询条件。</summary>
public sealed class GetFileOperationRecordsRequest
{
    /// <summary>开始时间，Unix 时间戳，单位为秒。</summary>
    [JsonPropertyName("start_time")] public required long StartTime { get; init; }

    /// <summary>结束时间，Unix 时间戳，单位为秒。</summary>
    [JsonPropertyName("end_time")] public required long EndTime { get; init; }

    /// <summary>文件操作者的成员账号，最多 100 个。</summary>
    [JsonPropertyName("userid_list")] public string[]? UserIdList { get; init; }

    /// <summary>文件操作筛选条件。</summary>
    [JsonPropertyName("operation")] public FileOperation? Operation { get; init; }

    /// <summary>上一页返回的游标，首页留空。</summary>
    [JsonPropertyName("cursor")] public string? Cursor { get; init; }

    /// <summary>返回条数上限，最多 1000 条。</summary>
    [JsonPropertyName("limit")] public int? Limit { get; init; }
}

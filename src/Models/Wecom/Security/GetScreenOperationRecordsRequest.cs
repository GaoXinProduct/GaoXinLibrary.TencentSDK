namespace GaoXinLibrary.TencentSDK.Wecom.Models.Security;

/// <summary>截屏和录屏操作记录查询条件。</summary>
public sealed class GetScreenOperationRecordsRequest
{
    /// <summary>开始时间，Unix 时间戳，单位为秒。</summary>
    [JsonPropertyName("start_time")] public required long StartTime { get; init; }

    /// <summary>结束时间，Unix 时间戳，单位为秒。</summary>
    [JsonPropertyName("end_time")] public required long EndTime { get; init; }

    /// <summary>操作成员的账号列表。</summary>
    [JsonPropertyName("userid_list")] public string[]? UserIdList { get; init; }

    /// <summary>要查询的部门 ID 列表。</summary>
    [JsonPropertyName("department_id_list")] public long[]? DepartmentIdList { get; init; }

    /// <summary>截屏和录屏内容类型。</summary>
    [JsonPropertyName("screen_shot_type")] public int? ScreenshotType { get; init; }

    /// <summary>上一页返回的游标，首页留空。</summary>
    [JsonPropertyName("cursor")] public string? Cursor { get; init; }

    /// <summary>本页返回数量上限。</summary>
    [JsonPropertyName("limit")] public int? Limit { get; init; }
}

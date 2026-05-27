using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.HomeSchool.Living;

public record GetLivingIdListRequest
{
    [JsonPropertyName("teacher_userid")] public string TeacherUserid { get; init; } = string.Empty;
    [JsonPropertyName("start_time")] public long? StartTime { get; init; }
    [JsonPropertyName("end_time")] public long? EndTime { get; init; }
}

public class GetLivingIdListResponse : WecomBaseResponse
{
    [JsonPropertyName("livingid_list")] public LivingIdItem[]? LivingidList { get; set; }
}

public record LivingIdItem
{
    [JsonPropertyName("livingid")] public string? Livingid { get; init; }
    [JsonPropertyName("create_time")] public long CreateTime { get; init; }
}

public record GetLivingDetailRequest
{
    [JsonPropertyName("livingid")] public string Livingid { get; init; } = string.Empty;
}

public class GetLivingDetailResponse : WecomBaseResponse
{
    [JsonPropertyName("living_info")] public LivingDetailInfo? LivingInfo { get; set; }
}

public record LivingDetailInfo
{
    [JsonPropertyName("livingid")] public string? Livingid { get; init; }
    [JsonPropertyName("title")] public string? Title { get; init; }
    [JsonPropertyName("teacher_name")] public string? TeacherName { get; init; }
    [JsonPropertyName("start_time")] public long StartTime { get; init; }
    [JsonPropertyName("end_time")] public long EndTime { get; init; }
    [JsonPropertyName("status")] public int Status { get; init; }
}

public record GetLivingWatchStatRequest
{
    [JsonPropertyName("livingid")] public string Livingid { get; init; } = string.Empty;
    [JsonPropertyName("department_id")] public int? DepartmentId { get; init; }
    [JsonPropertyName("start_time")] public long? StartTime { get; init; }
    [JsonPropertyName("end_time")] public long? EndTime { get; init; }
    [JsonPropertyName("cursor")] public string? Cursor { get; init; }
    [JsonPropertyName("limit")] public int? Limit { get; init; }
}

public class GetLivingWatchStatResponse : WecomBaseResponse
{
    [JsonPropertyName("watch_list")] public LivingWatchItem[]? WatchList { get; set; }
    [JsonPropertyName("next_cursor")] public string? NextCursor { get; set; }
    [JsonPropertyName("has_more")] public int HasMore { get; set; }
}

public record LivingWatchItem
{
    [JsonPropertyName("userid")] public string? Userid { get; init; }
    [JsonPropertyName("user_type")] public int UserType { get; init; }
    [JsonPropertyName("watch_time")] public long WatchTime { get; init; }
}

public record GetLivingNotWatchStatRequest
{
    [JsonPropertyName("livingid")] public string Livingid { get; init; } = string.Empty;
    [JsonPropertyName("department_id")] public int? DepartmentId { get; init; }
    [JsonPropertyName("start_time")] public long? StartTime { get; init; }
    [JsonPropertyName("end_time")] public long? EndTime { get; init; }
    [JsonPropertyName("cursor")] public string? Cursor { get; init; }
    [JsonPropertyName("limit")] public int? Limit { get; init; }
}

public class GetLivingNotWatchStatResponse : WecomBaseResponse
{
    [JsonPropertyName("not_watch_list")] public LivingNotWatchItem[]? NotWatchList { get; set; }
    [JsonPropertyName("next_cursor")] public string? NextCursor { get; set; }
    [JsonPropertyName("has_more")] public int HasMore { get; set; }
}

public record LivingNotWatchItem
{
    [JsonPropertyName("userid")] public string? Userid { get; init; }
    [JsonPropertyName("user_type")] public int UserType { get; init; }
}

public record DeleteReplayDataRequest
{
    [JsonPropertyName("livingid")] public string Livingid { get; init; } = string.Empty;
}

public class DeleteReplayDataResponse : WecomBaseResponse
{
}

public record GetLivingWatchStatV2Request
{
    [JsonPropertyName("livingid")] public string Livingid { get; init; } = string.Empty;
    [JsonPropertyName("department_id")] public int? DepartmentId { get; init; }
    [JsonPropertyName("start_time")] public long? StartTime { get; init; }
    [JsonPropertyName("end_time")] public long? EndTime { get; init; }
    [JsonPropertyName("cursor")] public string? Cursor { get; init; }
    [JsonPropertyName("limit")] public int? Limit { get; init; }
}

public class GetLivingWatchStatV2Response : WecomBaseResponse
{
    [JsonPropertyName("watch_list")] public LivingWatchV2Item[]? WatchList { get; set; }
    [JsonPropertyName("next_cursor")] public string? NextCursor { get; set; }
    [JsonPropertyName("has_more")] public int HasMore { get; set; }
}

public record LivingWatchV2Item
{
    [JsonPropertyName("userid")] public string? Userid { get; init; }
    [JsonPropertyName("user_type")] public int UserType { get; init; }
    [JsonPropertyName("watch_time")] public long WatchTime { get; init; }
    [JsonPropertyName("watch_duration")] public long WatchDuration { get; init; }
}

public record GetLivingNotWatchStatV2Request
{
    [JsonPropertyName("livingid")] public string Livingid { get; init; } = string.Empty;
    [JsonPropertyName("department_id")] public int? DepartmentId { get; init; }
    [JsonPropertyName("start_time")] public long? StartTime { get; init; }
    [JsonPropertyName("end_time")] public long? EndTime { get; init; }
    [JsonPropertyName("cursor")] public string? Cursor { get; init; }
    [JsonPropertyName("limit")] public int? Limit { get; init; }
}

public class GetLivingNotWatchStatV2Response : WecomBaseResponse
{
    [JsonPropertyName("not_watch_list")] public LivingNotWatchV2Item[]? NotWatchList { get; set; }
    [JsonPropertyName("next_cursor")] public string? NextCursor { get; set; }
    [JsonPropertyName("has_more")] public int HasMore { get; set; }
}

public record LivingNotWatchV2Item
{
    [JsonPropertyName("userid")] public string? Userid { get; init; }
    [JsonPropertyName("user_type")] public int UserType { get; init; }
}
using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.HomeSchool.Living;

public record GetLivingIdListRequest
{
    [JsonPropertyName("userid")] public string TeacherUserid { get; init; } = string.Empty;
    [JsonPropertyName("cursor")] public string? Cursor { get; init; }
    [JsonPropertyName("limit")] public int? Limit { get; init; }
    [Obsolete("老师直播列表仅按 Cursor 分页。"), JsonIgnore] public long? StartTime { get; init; }
    [Obsolete("老师直播列表仅按 Cursor 分页。"), JsonIgnore] public long? EndTime { get; init; }
}

public class GetLivingIdListResponse : WecomBaseResponse
{
    [JsonPropertyName("livingid_list")] public string[]? LivingIds { get; set; }
    [JsonPropertyName("next_cursor")] public string? NextCursor { get; set; }
    [JsonIgnore] public LivingIdItem[]? LivingidList { get; set; }
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
    [JsonIgnore] public string? Livingid { get; init; }
    [JsonPropertyName("theme")] public string? Title { get; init; }
    [JsonPropertyName("living_start")] public long StartTime { get; init; }
    [JsonPropertyName("living_duration")] public long Duration { get; init; }
    [JsonPropertyName("anchor_userid")] public string? AnchorUserid { get; init; }
    [JsonPropertyName("living_range")] public SchoolLivingRange? LivingRange { get; init; }
    [JsonPropertyName("viewer_num")] public int ViewerCount { get; init; }
    [JsonPropertyName("comment_num")] public int CommentCount { get; init; }
    [JsonPropertyName("open_replay")] public int OpenReplay { get; init; }
    [JsonPropertyName("push_stream_url")] public string? PushStreamUrl { get; init; }
    [JsonPropertyName("online_count")] public int? OnlineCount { get; init; }
    [JsonPropertyName("subscribe_count")] public int? SubscribeCount { get; init; }
    [Obsolete("请读取 AnchorUserid。"), JsonIgnore] public string? TeacherName { get; init; }
    [Obsolete("请读取 StartTime 和 Duration。"), JsonIgnore] public long EndTime { get; init; }
    [Obsolete("上课直播详情不返回状态。"), JsonIgnore] public int Status { get; init; }
}

public sealed record SchoolLivingRange
{
    [JsonPropertyName("partyids")] public int[]? PartyIds { get; init; }
    [JsonPropertyName("group_names")] public string[]? GroupNames { get; init; }
}

public record GetLivingWatchStatRequest
{
    [JsonPropertyName("livingid")] public string Livingid { get; init; } = string.Empty;
    [JsonPropertyName("next_key")] public string? NextKey { get; init; }
    [JsonIgnore] public string? Cursor { get => NextKey; init => NextKey = value; }
    [Obsolete("观看统计仅接受 Livingid 和 NextKey。"), JsonIgnore] public int? DepartmentId { get; init; }
    [Obsolete("观看统计仅接受 Livingid 和 NextKey。"), JsonIgnore] public long? StartTime { get; init; }
    [Obsolete("观看统计仅接受 Livingid 和 NextKey。"), JsonIgnore] public long? EndTime { get; init; }
    [Obsolete("观看统计仅接受 Livingid 和 NextKey。"), JsonIgnore] public int? Limit { get; init; }
}

public class GetLivingWatchStatResponse : WecomBaseResponse
{
    [JsonPropertyName("stat_infoes")] public SchoolLivingAttendance? StatInfo { get; set; }
    [JsonPropertyName("next_key")] public string? NextKey { get; set; }
    [JsonPropertyName("ending")] public int? Ending { get; set; }
    [JsonIgnore] public string? NextCursor { get => NextKey; set => NextKey = value; }
    [JsonIgnore] public int HasMore { get => Ending == 0 ? 1 : 0; set => Ending = value == 0 ? 1 : 0; }
    [Obsolete("请读取 StatInfo 内分组的观看记录。"), JsonIgnore] public LivingWatchItem[]? WatchList { get; set; }
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
    [JsonPropertyName("next_key")] public string? NextKey { get; init; }
    [JsonIgnore] public string? Cursor { get => NextKey; init => NextKey = value; }
    [Obsolete("未观看统计仅接受 Livingid 和 NextKey。"), JsonIgnore] public int? DepartmentId { get; init; }
    [Obsolete("未观看统计仅接受 Livingid 和 NextKey。"), JsonIgnore] public long? StartTime { get; init; }
    [Obsolete("未观看统计仅接受 Livingid 和 NextKey。"), JsonIgnore] public long? EndTime { get; init; }
    [Obsolete("未观看统计仅接受 Livingid 和 NextKey。"), JsonIgnore] public int? Limit { get; init; }
}

public class GetLivingNotWatchStatResponse : WecomBaseResponse
{
    [JsonPropertyName("stat_info")] public SchoolLivingAttendance? StatInfo { get; set; }
    [JsonPropertyName("next_key")] public string? NextKey { get; set; }
    [JsonPropertyName("ending")] public int? Ending { get; set; }
    [JsonIgnore] public string? NextCursor { get => NextKey; set => NextKey = value; }
    [JsonIgnore] public int HasMore { get => Ending == 0 ? 1 : 0; set => Ending = value == 0 ? 1 : 0; }
    [Obsolete("请读取 StatInfo 内分组的未观看记录。"), JsonIgnore] public LivingNotWatchItem[]? NotWatchList { get; set; }
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
    [JsonPropertyName("next_cursor")] public string? NextCursor { get; init; }
    [JsonIgnore] public string? Cursor { get => NextCursor; init => NextCursor = value; }
    [Obsolete("观看统计仅接受 Livingid 和 NextCursor。"), JsonIgnore] public int? DepartmentId { get; init; }
    [Obsolete("观看统计仅接受 Livingid 和 NextCursor。"), JsonIgnore] public long? StartTime { get; init; }
    [Obsolete("观看统计仅接受 Livingid 和 NextCursor。"), JsonIgnore] public long? EndTime { get; init; }
    [Obsolete("观看统计仅接受 Livingid 和 NextCursor。"), JsonIgnore] public int? Limit { get; init; }
}

public class GetLivingWatchStatV2Response : WecomBaseResponse
{
    [JsonPropertyName("stat_info")] public SchoolLivingAttendance? StatInfo { get; set; }
    [JsonPropertyName("next_cursor")] public string? NextCursor { get; set; }
    [JsonPropertyName("has_more")] public int HasMore { get; set; }
    [Obsolete("请读取 StatInfo 内分组的观看记录。"), JsonIgnore] public LivingWatchV2Item[]? WatchList { get; set; }
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
    [JsonPropertyName("next_cursor")] public string? NextCursor { get; init; }
    [JsonIgnore] public string? Cursor { get => NextCursor; init => NextCursor = value; }
    [Obsolete("未观看统计仅接受 Livingid 和 NextCursor。"), JsonIgnore] public int? DepartmentId { get; init; }
    [Obsolete("未观看统计仅接受 Livingid 和 NextCursor。"), JsonIgnore] public long? StartTime { get; init; }
    [Obsolete("未观看统计仅接受 Livingid 和 NextCursor。"), JsonIgnore] public long? EndTime { get; init; }
    [Obsolete("未观看统计仅接受 Livingid 和 NextCursor。"), JsonIgnore] public int? Limit { get; init; }
}

public class GetLivingNotWatchStatV2Response : WecomBaseResponse
{
    [JsonPropertyName("stat_info")] public SchoolLivingAttendance? StatInfo { get; set; }
    [JsonPropertyName("next_cursor")] public string? NextCursor { get; set; }
    [JsonPropertyName("has_more")] public int HasMore { get; set; }
    [Obsolete("请读取 StatInfo 内分组的未观看记录。"), JsonIgnore] public LivingNotWatchV2Item[]? NotWatchList { get; set; }
}

public record LivingNotWatchV2Item
{
    [JsonPropertyName("userid")] public string? Userid { get; init; }
    [JsonPropertyName("user_type")] public int UserType { get; init; }
}

public sealed record SchoolLivingAttendance
{
    [JsonPropertyName("students")] public SchoolLivingAttendee[]? Students { get; init; }
    [JsonPropertyName("parents")] public SchoolLivingAttendee[]? Parents { get; init; }
    [JsonPropertyName("visitors")] public SchoolLivingAttendee[]? Visitors { get; init; }
}

public sealed record SchoolLivingAttendee
{
    [JsonPropertyName("student_userid")] public string? StudentUserid { get; init; }
    [JsonPropertyName("parent_userid")] public string? ParentUserid { get; init; }
    [JsonPropertyName("partyids")] public int[]? PartyIds { get; init; }
    [JsonPropertyName("nickname")] public string? Nickname { get; init; }
    [JsonPropertyName("watch_time")] public long? WatchTime { get; init; }
    [JsonPropertyName("enter_time")] public long? EnterTime { get; init; }
    [JsonPropertyName("leave_time")] public long? LeaveTime { get; init; }
    [JsonPropertyName("is_comment")] public int? IsComment { get; init; }
}

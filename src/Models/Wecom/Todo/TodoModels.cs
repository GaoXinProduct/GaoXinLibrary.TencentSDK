using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Todo;

/// <summary>待办及参与人的完成状态。</summary>
public enum TodoStatus
{
    Completed = 0,
    InProgress = 1
}

/// <summary>待办参与人及其处理状态。</summary>
public sealed record TodoAttendee
{
    [JsonPropertyName("userid")] public required string UserId { get; init; }
    [JsonPropertyName("status")] public required TodoStatus Status { get; init; }
}

/// <summary>待办提醒时间。</summary>
public sealed record TodoReminder
{
    [JsonPropertyName("remind_time")] public long RemindTime { get; init; }
}

/// <summary>待办详情。</summary>
public sealed class GetTodoResponse : WecomBaseResponse
{
    [JsonPropertyName("content")] public string? Content { get; init; }
    [JsonPropertyName("creator")] public string? CreatorUserId { get; init; }
    [JsonPropertyName("status")] public TodoStatus Status { get; init; }
    [JsonPropertyName("create_time")] public long CreateTime { get; init; }
    [JsonPropertyName("attendees")] public TodoAttendee[]? Attendees { get; init; }
    [JsonPropertyName("end_time")] public long? EndTime { get; init; }
    [JsonPropertyName("reminders")] public TodoReminder[]? Reminders { get; init; }
}

/// <summary>更新待办状态和参与人。</summary>
public sealed record UpdateTodoRequest
{
    [JsonPropertyName("todo_id")] public required string TodoId { get; init; }

    /// <summary>待办整体状态。留空时保留现有状态。</summary>
    [JsonPropertyName("status")] public TodoStatus? Status { get; init; }

    /// <summary>待办参与人列表，最多 20 个。留空或传空数组时保留现有列表。</summary>
    [JsonPropertyName("attendees")] public TodoAttendee[]? Attendees { get; init; }
}

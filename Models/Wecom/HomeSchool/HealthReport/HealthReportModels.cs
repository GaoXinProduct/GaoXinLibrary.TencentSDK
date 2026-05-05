using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.HomeSchool.HealthReport;

public record GetHealthReportStatRequest
{
    [JsonPropertyName("department_id")] public int DepartmentId { get; init; }
    [JsonPropertyName("start_time")] public long? StartTime { get; init; }
    [JsonPropertyName("end_time")] public long? EndTime { get; init; }
}

public class GetHealthReportStatResponse : WecomBaseResponse
{
    [JsonPropertyName("stat_list")] public HealthReportStatItem[]? StatList { get; set; }
}

public record HealthReportStatItem
{
    [JsonPropertyName("date")] public string? Date { get; init; }
    [JsonPropertyName("total")] public int Total { get; init; }
    [JsonPropertyName("filled")] public int Filled { get; init; }
}

public record GetHealthReportTaskIdListRequest
{
    [JsonPropertyName("department_id")] public int DepartmentId { get; init; }
    [JsonPropertyName("start_time")] public long? StartTime { get; init; }
    [JsonPropertyName("end_time")] public long? EndTime { get; init; }
    [JsonPropertyName("cursor")] public string? Cursor { get; init; }
    [JsonPropertyName("limit")] public int? Limit { get; init; }
}

public class GetHealthReportTaskIdListResponse : WecomBaseResponse
{
    [JsonPropertyName("task_id_list")] public TaskIdItem[]? TaskIdList { get; set; }
    [JsonPropertyName("next_cursor")] public string? NextCursor { get; set; }
    [JsonPropertyName("has_more")] public int HasMore { get; set; }
}

public record TaskIdItem
{
    [JsonPropertyName("task_id")] public string? TaskId { get; init; }
    [JsonPropertyName("create_time")] public long CreateTime { get; init; }
}

public record GetHealthReportTaskDetailRequest
{
    [JsonPropertyName("task_id")] public string TaskId { get; init; } = string.Empty;
}

public class GetHealthReportTaskDetailResponse : WecomBaseResponse
{
    [JsonPropertyName("task_info")] public HealthReportTaskInfo? TaskInfo { get; set; }
}

public record HealthReportTaskInfo
{
    [JsonPropertyName("task_id")] public string? TaskId { get; init; }
    [JsonPropertyName("task_name")] public string? TaskName { get; init; }
    [JsonPropertyName("create_time")] public long CreateTime { get; init; }
    [JsonPropertyName("deadline")] public long? Deadline { get; init; }
    [JsonPropertyName("status")] public int Status { get; init; }
}

public record GetHealthReportAnswersRequest
{
    [JsonPropertyName("task_id")] public string TaskId { get; init; } = string.Empty;
    [JsonPropertyName("department_id")] public int? DepartmentId { get; init; }
    [JsonPropertyName("start_time")] public long? StartTime { get; init; }
    [JsonPropertyName("end_time")] public long? EndTime { get; init; }
    [JsonPropertyName("cursor")] public string? Cursor { get; init; }
    [JsonPropertyName("limit")] public int? Limit { get; init; }
}

public class GetHealthReportAnswersResponse : WecomBaseResponse
{
    [JsonPropertyName("answer_list")] public HealthReportAnswer[]? AnswerList { get; set; }
    [JsonPropertyName("next_cursor")] public string? NextCursor { get; set; }
    [JsonPropertyName("has_more")] public int HasMore { get; set; }
}

public record HealthReportAnswer
{
    [JsonPropertyName("user_id")] public string? UserId { get; init; }
    [JsonPropertyName("user_type")] public int UserType { get; init; }
    [JsonPropertyName("answer_time")] public long AnswerTime { get; init; }
    [JsonPropertyName("answers")] public string? Answers { get; init; }
}
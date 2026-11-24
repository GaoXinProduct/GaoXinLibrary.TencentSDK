using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.HomeSchool.HealthReport;

public record GetHealthReportStatRequest
{
    /// <summary>统计日期，格式为 yyyy-MM-dd。</summary>
    [JsonPropertyName("date")] public string Date { get; init; } = string.Empty;
    [Obsolete("健康上报使用统计仅支持指定 Date。"), JsonIgnore] public int DepartmentId { get; init; }
    [Obsolete("请使用 Date 指定要查询的日期。"), JsonIgnore] public long? StartTime { get; init; }
    [Obsolete("请使用 Date 指定要查询的日期。"), JsonIgnore] public long? EndTime { get; init; }
}

public class GetHealthReportStatResponse : WecomBaseResponse
{
    [JsonPropertyName("pv")] public int PageViews { get; set; }
    [JsonPropertyName("uv")] public int UniqueUsers { get; set; }
    [Obsolete("请读取 PageViews 和 UniqueUsers。"), JsonIgnore] public HealthReportStatItem[]? StatList { get; set; }
}

public record HealthReportStatItem
{
    [JsonPropertyName("date")] public string? Date { get; init; }
    [JsonPropertyName("total")] public int Total { get; init; }
    [JsonPropertyName("filled")] public int Filled { get; init; }
}

public record GetHealthReportTaskIdListRequest
{
    [JsonPropertyName("offset")] public int? Offset { get; init; }
    [JsonPropertyName("limit")] public int? Limit { get; init; }
    [Obsolete("任务列表不支持按部门查询。"), JsonIgnore] public int DepartmentId { get; init; }
    [Obsolete("任务列表不支持按时间过滤。"), JsonIgnore] public long? StartTime { get; init; }
    [Obsolete("任务列表不支持按时间过滤。"), JsonIgnore] public long? EndTime { get; init; }
    [Obsolete("任务列表按 Offset 分页。"), JsonIgnore] public string? Cursor { get; init; }
}

public class GetHealthReportTaskIdListResponse : WecomBaseResponse
{
    [JsonPropertyName("jobids")] public string[]? JobIds { get; set; }
    [JsonPropertyName("ending")] public int? Ending { get; set; }
    [JsonIgnore] public TaskIdItem[]? TaskIdList { get; set; }
    [Obsolete("任务列表按 Offset 分页。"), JsonIgnore] public string? NextCursor { get; set; }
    [JsonIgnore]
    public int HasMore
    {
        get => Ending == 0 ? 1 : 0;
        set => Ending = value == 0 ? 1 : 0;
    }
}

public record TaskIdItem
{
    [JsonPropertyName("task_id")] public string? TaskId { get; init; }
    [JsonPropertyName("create_time")] public long CreateTime { get; init; }
}

public record GetHealthReportTaskDetailRequest
{
    [JsonPropertyName("jobid")] public string TaskId { get; init; } = string.Empty;
    /// <summary>查询日期，格式为 yyyy-MM-dd。</summary>
    [JsonPropertyName("date")] public string Date { get; init; } = string.Empty;
}

public class GetHealthReportTaskDetailResponse : WecomBaseResponse
{
    [JsonPropertyName("job_info")] public HealthReportTaskInfo? TaskInfo { get; set; }
}

public record HealthReportTaskInfo
{
    [JsonIgnore] public string? TaskId { get; init; }
    [JsonPropertyName("title")] public string? TaskName { get; init; }
    [JsonPropertyName("creator")] public string? Creator { get; init; }
    [JsonPropertyName("type")] public int Type { get; init; }
    [JsonPropertyName("apply_range")] public HealthReportScope? ApplyRange { get; init; }
    [JsonPropertyName("report_to")] public HealthReportScope? ReportTo { get; init; }
    [JsonPropertyName("report_type")] public int ReportType { get; init; }
    [JsonPropertyName("skip_weekend")] public int SkipWeekend { get; init; }
    [JsonPropertyName("finish_cnt")] public int FinishedCount { get; init; }
    [JsonPropertyName("question_templates")] public HealthReportQuestion[]? QuestionTemplates { get; init; }
    [Obsolete("健康上报任务详情不返回创建时间。"), JsonIgnore] public long CreateTime { get; init; }
    [Obsolete("健康上报任务详情不返回截止时间。"), JsonIgnore] public long? Deadline { get; init; }
    [Obsolete("健康上报任务详情不返回状态。"), JsonIgnore] public int Status { get; init; }
}

public sealed record HealthReportScope
{
    [JsonPropertyName("userids")] public string[]? UserIds { get; init; }
    [JsonPropertyName("partyids")] public int[]? PartyIds { get; init; }
}

public sealed record HealthReportQuestion
{
    [JsonPropertyName("question_id")] public int QuestionId { get; init; }
    [JsonPropertyName("title")] public string? Title { get; init; }
    [JsonPropertyName("question_type")] public int QuestionType { get; init; }
    [JsonPropertyName("is_required")] public int IsRequired { get; init; }
    [JsonPropertyName("option_list")] public HealthReportQuestionOption[]? Options { get; init; }
}

public sealed record HealthReportQuestionOption
{
    [JsonPropertyName("option_id")] public int OptionId { get; init; }
    [JsonPropertyName("option_text")] public string? OptionText { get; init; }
}

public record GetHealthReportAnswersRequest
{
    [JsonPropertyName("jobid")] public string TaskId { get; init; } = string.Empty;
    /// <summary>查询日期，格式为 yyyy-MM-dd。</summary>
    [JsonPropertyName("date")] public string Date { get; init; } = string.Empty;
    [JsonPropertyName("offset")] public int? Offset { get; init; }
    [JsonPropertyName("limit")] public int? Limit { get; init; }
    [Obsolete("答案列表不支持按部门查询。"), JsonIgnore] public int? DepartmentId { get; init; }
    [Obsolete("请使用 Date 指定查询日期。"), JsonIgnore] public long? StartTime { get; init; }
    [Obsolete("请使用 Date 指定查询日期。"), JsonIgnore] public long? EndTime { get; init; }
    [Obsolete("答案列表按 Offset 分页。"), JsonIgnore] public string? Cursor { get; init; }
}

public class GetHealthReportAnswersResponse : WecomBaseResponse
{
    [JsonPropertyName("answers")] public HealthReportAnswer[]? AnswerList { get; set; }
    [JsonPropertyName("creator")] public string? Creator { get; set; }
    [Obsolete("答案列表按 Offset 分页。"), JsonIgnore] public string? NextCursor { get; set; }
    [Obsolete("答案列表不返回是否有下一页。"), JsonIgnore] public int HasMore { get; set; }
}

public record HealthReportAnswer
{
    [JsonPropertyName("userid")] public string? UserId { get; init; }
    [JsonPropertyName("id_type")] public int UserType { get; init; }
    [JsonPropertyName("student_userid")] public string? StudentUserid { get; init; }
    [JsonPropertyName("parent_userid")] public string? ParentUserid { get; init; }
    [JsonPropertyName("report_time")] public long AnswerTime { get; init; }
    [JsonPropertyName("report_values")] public HealthReportValue[]? ReportValues { get; init; }
    [Obsolete("请读取 ReportValues。"), JsonIgnore] public string? Answers { get; init; }
}

public sealed record HealthReportValue
{
    [JsonPropertyName("question_id")] public int QuestionId { get; init; }
    [JsonPropertyName("single_choice")] public int? SingleChoice { get; init; }
    [JsonPropertyName("multi_choice")] public int[]? MultiChoice { get; init; }
    [JsonPropertyName("text")] public string? Text { get; init; }
    [JsonPropertyName("fileid")] public string[]? FileIds { get; init; }
    [JsonPropertyName("url")] public string? Url { get; init; }
    [JsonPropertyName("itinerary_card_type")] public int? ItineraryCardType { get; init; }
    [JsonPropertyName("high_risk_area")] public JsonElement? HighRiskArea { get; init; }
}

using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.HomeSchool.Student;

public record CreateStudentRequest
{
    [JsonPropertyName("student_userid")] public string StudentUserid { get; init; } = string.Empty;
    [JsonPropertyName("name")] public string Name { get; init; } = string.Empty;
    [JsonPropertyName("department")] public int[]? Department { get; init; }
    [JsonPropertyName("mobile")] public string? Mobile { get; init; }
    [JsonPropertyName("students")] public StudentInfo? Students { get; init; }
}

public class CreateStudentResponse : WecomBaseResponse
{
    [JsonPropertyName("result")] public StudentCreateResult? Result { get; set; }
}

public record StudentCreateResult
{
    [JsonPropertyName("student_userid")] public string? StudentUserid { get; init; }
    [JsonPropertyName("err_msg")] public string? ErrMsg { get; init; }
}

public record DeleteStudentRequest
{
    [JsonPropertyName("student_userid")] public string StudentUserid { get; init; } = string.Empty;
}

public class DeleteStudentResponse : WecomBaseResponse
{
}

public record UpdateStudentRequest
{
    [JsonPropertyName("student_userid")] public string StudentUserid { get; init; } = string.Empty;
    [JsonPropertyName("name")] public string? Name { get; init; }
    [JsonPropertyName("department")] public int[]? Department { get; init; }
    [JsonPropertyName("mobile")] public string? Mobile { get; init; }
    [JsonPropertyName("students")] public StudentInfo? Students { get; init; }
}

public class UpdateStudentResponse : WecomBaseResponse
{
}

public record BatchCreateStudentRequest
{
    [JsonPropertyName("students")] public StudentInfo[] Students { get; init; } = [];
}

public class BatchCreateStudentResponse : WecomBaseResponse
{
    [JsonPropertyName("result")] public StudentBatchResult[]? Result { get; set; }
}

public record StudentBatchResult
{
    [JsonPropertyName("student_userid")] public string? StudentUserid { get; init; }
    [JsonPropertyName("err_msg")] public string? ErrMsg { get; init; }
}

public record BatchDeleteStudentRequest
{
    [JsonPropertyName("student_userids")] public string[] StudentUserids { get; init; } = [];
}

public class BatchDeleteStudentResponse : WecomBaseResponse
{
    [JsonPropertyName("result")] public StudentBatchResult[]? Result { get; set; }
}

public record BatchUpdateStudentRequest
{
    [JsonPropertyName("students")] public StudentInfo[] Students { get; init; } = [];
}

public class BatchUpdateStudentResponse : WecomBaseResponse
{
    [JsonPropertyName("result")] public StudentBatchResult[]? Result { get; set; }
}

public record GetStudentRequest
{
    [JsonPropertyName("student_userid")] public string StudentUserid { get; init; } = string.Empty;
}

public class GetStudentResponse : WecomBaseResponse
{
    [JsonPropertyName("student_info")] public StudentInfo? StudentInfo { get; set; }
}

public record StudentInfo
{
    [JsonPropertyName("student_userid")] public string? StudentUserid { get; init; }
    [JsonPropertyName("name")] public string? Name { get; init; }
    [JsonPropertyName("department")] public int[]? Department { get; init; }
    [JsonPropertyName("mobile")] public string? Mobile { get; init; }
    [JsonPropertyName("student_number")] public string? StudentNumber { get; init; }
    [JsonPropertyName("classes")] public StudentClassInfo[]? Classes { get; init; }
}

public record StudentClassInfo
{
    [JsonPropertyName("class_id")] public int? ClassId { get; init; }
    [JsonPropertyName("grade_id")] public int? GradeId { get; init; }
}

public record GetDepartmentStudentsDetailRequest
{
    [JsonPropertyName("department_id")] public int DepartmentId { get; init; }
    [JsonPropertyName("fetch_child")] public int? FetchChild { get; init; }
    [JsonPropertyName("cursor")] public string? Cursor { get; init; }
    [JsonPropertyName("limit")] public int? Limit { get; init; }
}

public class GetDepartmentStudentsDetailResponse : WecomBaseResponse
{
    [JsonPropertyName("students")] public StudentInfo[]? Students { get; set; }
    [JsonPropertyName("next_cursor")] public string? NextCursor { get; set; }
    [JsonPropertyName("has_more")] public int HasMore { get; set; }
}

public record GetDepartmentParentsDetailRequest
{
    [JsonPropertyName("department_id")] public int DepartmentId { get; init; }
    [JsonPropertyName("fetch_child")] public int? FetchChild { get; init; }
    [JsonPropertyName("cursor")] public string? Cursor { get; init; }
    [JsonPropertyName("limit")] public int? Limit { get; init; }
}

public class GetDepartmentParentsDetailResponse : WecomBaseResponse
{
    [JsonPropertyName("parent_list")] public ParentInfo[]? ParentList { get; set; }
    [JsonPropertyName("next_cursor")] public string? NextCursor { get; set; }
    [JsonPropertyName("has_more")] public int HasMore { get; set; }
}

public record ParentInfo
{
    [JsonPropertyName("parent_userid")] public string? ParentUserid { get; init; }
    [JsonPropertyName("name")] public string? Name { get; init; }
    [JsonPropertyName("department")] public int[]? Department { get; init; }
    [JsonPropertyName("mobile")] public string? Mobile { get; init; }
    [JsonPropertyName("children")] public ParentChildInfo[]? Children { get; init; }
}

public record ParentChildInfo
{
    [JsonPropertyName("student_userid")] public string? StudentUserid { get; init; }
    [JsonPropertyName("student_name")] public string? StudentName { get; init; }
    [JsonPropertyName("relation")] public string? Relation { get; init; }
}

public record SetAutoSyncModeRequest
{
    [JsonPropertyName("auto_sync")] public int AutoSync { get; init; }
}

public class SetAutoSyncModeResponse : WecomBaseResponse
{
}

public record StandardGradeRequest
{
}

public class StandardGradeResponse : WecomBaseResponse
{
    [JsonPropertyName("grade_list")] public StandardGradeInfo[]? GradeList { get; set; }
}

public record StandardGradeInfo
{
    [JsonPropertyName("standard_grade")] public int? StandardGrade { get; init; }
    [JsonPropertyName("grade_name")] public string? GradeName { get; init; }
}

public record UpdateAutoUpgradeConfigRequest
{
    [JsonPropertyName("upgrade_time")] public string? UpgradeTime { get; init; }
    [JsonPropertyName("upgrade_type")] public int? UpgradeType { get; init; }
}

public class UpdateAutoUpgradeConfigResponse : WecomBaseResponse
{
}
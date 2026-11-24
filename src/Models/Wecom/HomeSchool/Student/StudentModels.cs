using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.HomeSchool.Student;

public record CreateStudentRequest
{
    [JsonPropertyName("student_userid")] public string StudentUserid { get; init; } = string.Empty;
    [JsonPropertyName("name")] public string Name { get; init; } = string.Empty;
    [JsonPropertyName("department")] public int[]? Department { get; init; }
    [JsonPropertyName("mobile")] public string? Mobile { get; init; }
    [JsonPropertyName("to_invite")] public bool? ToInvite { get; init; }
    [Obsolete("创建学生时，请直接设置请求字段。"), JsonIgnore] public StudentInfo? Students { get; init; }
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
    [JsonPropertyName("new_student_userid")] public string? NewStudentUserid { get; init; }
    [Obsolete("更新学生时，请直接设置请求字段。"), JsonIgnore] public StudentInfo? Students { get; init; }
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
    [JsonPropertyName("result_list")] public StudentBatchResult[]? Result { get; set; }
}

public record StudentBatchResult
{
    [JsonPropertyName("student_userid")] public string? StudentUserid { get; init; }
    [JsonPropertyName("errcode")] public int ErrCode { get; init; }
    [JsonPropertyName("errmsg")] public string? ErrMsg { get; init; }
}

public record BatchDeleteStudentRequest
{
    [JsonPropertyName("useridlist")] public string[] StudentUserids { get; init; } = [];
}

public class BatchDeleteStudentResponse : WecomBaseResponse
{
    [JsonPropertyName("result_list")] public StudentBatchResult[]? Result { get; set; }
}

public record BatchUpdateStudentRequest
{
    [JsonPropertyName("students")] public StudentInfo[] Students { get; init; } = [];
}

public class BatchUpdateStudentResponse : WecomBaseResponse
{
    [JsonPropertyName("result_list")] public StudentBatchResult[]? Result { get; set; }
}

public record GetStudentRequest
{
    [JsonPropertyName("student_userid")] public string StudentUserid { get; init; } = string.Empty;
}

public class GetStudentResponse : WecomBaseResponse
{
    [JsonPropertyName("user_type")] public int UserType { get; set; }
    [JsonPropertyName("student")] public StudentInfo? StudentInfo { get; set; }
}

public record StudentInfo
{
    [JsonPropertyName("student_userid")] public string? StudentUserid { get; init; }
    [JsonPropertyName("name")] public string? Name { get; init; }
    [JsonPropertyName("department")] public int[]? Department { get; init; }
    [JsonPropertyName("mobile")] public string? Mobile { get; init; }
    [JsonPropertyName("student_number")] public string? StudentNumber { get; init; }
    [JsonPropertyName("classes")] public StudentClassInfo[]? Classes { get; init; }
    [JsonPropertyName("parents")] public StudentParentInfo[]? Parents { get; init; }
    [JsonPropertyName("to_invite")] public bool? ToInvite { get; init; }
    [JsonPropertyName("new_student_userid")] public string? NewStudentUserid { get; init; }
}

public sealed record StudentParentInfo
{
    [JsonPropertyName("parent_userid")] public string? ParentUserid { get; init; }
    [JsonPropertyName("relation")] public string? Relation { get; init; }
    [JsonPropertyName("mobile")] public string? Mobile { get; init; }
    [JsonPropertyName("is_subscribe")] public int? IsSubscribe { get; init; }
    [JsonPropertyName("external_userid")] public string? ExternalUserid { get; init; }
}

public record StudentClassInfo
{
    [JsonPropertyName("class_id")] public int? ClassId { get; init; }
    [JsonPropertyName("grade_id")] public int? GradeId { get; init; }
}

public record GetDepartmentStudentsDetailRequest
{
    [JsonPropertyName("department_id")] public int DepartmentId { get; init; }
    [Obsolete("部门学生列表仅接受 DepartmentId。"), JsonIgnore] public int? FetchChild { get; init; }
    [Obsolete("部门学生列表不支持分页。"), JsonIgnore] public string? Cursor { get; init; }
    [Obsolete("部门学生列表不支持分页。"), JsonIgnore] public int? Limit { get; init; }
}

public class GetDepartmentStudentsDetailResponse : WecomBaseResponse
{
    [JsonPropertyName("students")] public StudentInfo[]? Students { get; set; }
    [Obsolete("部门学生列表不支持分页。"), JsonIgnore] public string? NextCursor { get; set; }
    [Obsolete("部门学生列表不支持分页。"), JsonIgnore] public int HasMore { get; set; }
}

public record GetDepartmentParentsDetailRequest
{
    [JsonPropertyName("department_id")] public int DepartmentId { get; init; }
    [Obsolete("部门家长列表仅接受 DepartmentId。"), JsonIgnore] public int? FetchChild { get; init; }
    [Obsolete("部门家长列表不支持分页。"), JsonIgnore] public string? Cursor { get; init; }
    [Obsolete("部门家长列表不支持分页。"), JsonIgnore] public int? Limit { get; init; }
}

public class GetDepartmentParentsDetailResponse : WecomBaseResponse
{
    [JsonPropertyName("parents")] public ParentInfo[]? ParentList { get; set; }
    [Obsolete("部门家长列表不支持分页。"), JsonIgnore] public string? NextCursor { get; set; }
    [Obsolete("部门家长列表不支持分页。"), JsonIgnore] public int HasMore { get; set; }
}

public record ParentInfo
{
    [JsonPropertyName("parent_userid")] public string? ParentUserid { get; init; }
    [JsonPropertyName("name")] public string? Name { get; init; }
    [JsonPropertyName("department")] public int[]? Department { get; init; }
    [JsonPropertyName("mobile")] public string? Mobile { get; init; }
    [JsonPropertyName("is_subscribe")] public int? IsSubscribe { get; init; }
    [JsonPropertyName("external_userid")] public string? ExternalUserid { get; init; }
    [JsonPropertyName("children")] public ParentChildInfo[]? Children { get; init; }
}

public record ParentChildInfo
{
    [JsonPropertyName("student_userid")] public string? StudentUserid { get; init; }
    [JsonPropertyName("name")] public string? StudentName { get; init; }
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

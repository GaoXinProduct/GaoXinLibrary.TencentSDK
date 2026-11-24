using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.HomeSchool.Department;

public record CreateDepartmentRequest
{
    [JsonPropertyName("name")] public string Name { get; init; } = string.Empty;
    [JsonPropertyName("parentid")] public int ParentId { get; init; }
    [JsonPropertyName("order")] public int? Order { get; init; }
    [JsonPropertyName("id")] public int? Id { get; init; }
    [JsonPropertyName("type")] public int? Type { get; init; }
    [JsonPropertyName("register_year")] public int? RegisterYear { get; init; }
    [JsonPropertyName("standard_grade")] public int? StandardGrade { get; init; }
    [JsonPropertyName("department_admins")] public DepartmentAdmin[]? DepartmentAdmins { get; init; }
}

public class CreateDepartmentResponse : WecomBaseResponse
{
    [JsonPropertyName("id")] public int Id { get; set; }
}

public record UpdateDepartmentRequest
{
    [JsonPropertyName("id")] public int Id { get; init; }
    [JsonPropertyName("name")] public string? Name { get; init; }
    [JsonPropertyName("parentid")] public int? ParentId { get; init; }
    [JsonPropertyName("order")] public int? Order { get; init; }
    [JsonPropertyName("new_id")] public int? NewId { get; init; }
    [JsonPropertyName("register_year")] public int? RegisterYear { get; init; }
    [JsonPropertyName("standard_grade")] public int? StandardGrade { get; init; }
    [JsonPropertyName("department_admins")] public DepartmentAdmin[]? DepartmentAdmins { get; init; }
}

public class UpdateDepartmentResponse : WecomBaseResponse
{
}

public record DeleteDepartmentRequest
{
    [JsonPropertyName("id")] public int Id { get; init; }
}

public class DeleteDepartmentResponse : WecomBaseResponse
{
}

public record GetDepartmentListRequest
{
    [JsonPropertyName("id")] public int? Id { get; init; }
}

public class GetDepartmentListResponse : WecomBaseResponse
{
    [JsonPropertyName("departments")] public DepartmentInfo[]? Department { get; set; }
}

public record DepartmentInfo
{
    [JsonPropertyName("id")] public int Id { get; init; }
    [JsonPropertyName("name")] public string? Name { get; init; }
    [JsonPropertyName("parentid")] public int ParentId { get; init; }
    [JsonPropertyName("order")] public int Order { get; init; }
    [JsonPropertyName("type")] public int? Type { get; init; }
    [JsonPropertyName("register_year")] public int? RegisterYear { get; init; }
    [JsonPropertyName("standard_grade")] public int? StandardGrade { get; init; }
    [JsonPropertyName("is_graduated")] public int? IsGraduated { get; init; }
    [JsonPropertyName("open_group_chat")] public int? OpenGroupChat { get; init; }
    [JsonPropertyName("group_chat_id")] public string? GroupChatId { get; init; }
    [JsonPropertyName("department_admins")] public DepartmentAdmin[]? DepartmentAdmins { get; init; }
}

public sealed record DepartmentAdmin
{
    [JsonPropertyName("userid")] public string? UserId { get; init; }
    [JsonPropertyName("type")] public int? Type { get; init; }
    [JsonPropertyName("subject")] public string? Subject { get; init; }
    [JsonPropertyName("op")] public int? Operation { get; init; }
}

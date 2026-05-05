using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.HomeSchool.Department;

public record CreateDepartmentRequest
{
    [JsonPropertyName("name")] public string Name { get; init; } = string.Empty;
    [JsonPropertyName("parentid")] public int ParentId { get; init; }
    [JsonPropertyName("order")] public int? Order { get; init; }
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
    [JsonPropertyName("department")] public DepartmentInfo[]? Department { get; set; }
}

public record DepartmentInfo
{
    [JsonPropertyName("id")] public int Id { get; init; }
    [JsonPropertyName("name")] public string? Name { get; init; }
    [JsonPropertyName("parentid")] public int ParentId { get; init; }
    [JsonPropertyName("order")] public int Order { get; init; }
}
using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.HomeSchool.Callback;

public record HomeSchoolMemberChangeEvent
{
    [JsonPropertyName("ChangeType")] public string? ChangeType { get; init; }
    [JsonPropertyName("UserID")] public string? UserId { get; init; }
    [JsonPropertyName("SchoolId")] public string? SchoolId { get; init; }
    [JsonPropertyName("InstanceId")] public long InstanceId { get; init; }
    [JsonPropertyName("ChangeInfo")] public MemberChangeInfo? ChangeInfo { get; init; }
}

public record MemberChangeInfo
{
    [JsonPropertyName("Type")] public string? Type { get; init; }
    [JsonPropertyName("UserType")] public int UserType { get; init; }
    [JsonPropertyName("Id")] public string? Id { get; init; }
}

public record HomeSchoolDepartmentChangeEvent
{
    [JsonPropertyName("ChangeType")] public string? ChangeType { get; init; }
    [JsonPropertyName("SchoolId")] public string? SchoolId { get; init; }
    [JsonPropertyName("InstanceId")] public long InstanceId { get; init; }
    [JsonPropertyName("DepartmentId")] public int DepartmentId { get; init; }
}
using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.HomeSchool.Parent;

public record ParentChildInfo
{
    [JsonPropertyName("student_userid")] public string StudentUserid { get; init; } = string.Empty;
    [JsonPropertyName("relation")] public string? Relation { get; init; }
}

public record ParentBatchResult
{
    [JsonPropertyName("parent_userid")] public string? ParentUserid { get; init; }
    [JsonPropertyName("err_msg")] public string? ErrMsg { get; init; }
}

public record ParentInfo
{
    [JsonPropertyName("parent_userid")] public string? ParentUserid { get; init; }
    [JsonPropertyName("name")] public string? Name { get; init; }
    [JsonPropertyName("department")] public int[]? Department { get; init; }
    [JsonPropertyName("mobile")] public string? Mobile { get; init; }
    [JsonPropertyName("children")] public ParentChildInfo[]? Children { get; init; }
}

public record CreateParentRequest
{
    [JsonPropertyName("parent_userid")] public string ParentUserid { get; init; } = string.Empty;
    [JsonPropertyName("name")] public string Name { get; init; } = string.Empty;
    [JsonPropertyName("department")] public int[]? Department { get; init; }
    [JsonPropertyName("mobile")] public string? Mobile { get; init; }
    [JsonPropertyName("children")] public ParentChildInfo? Children { get; init; }
}

public class CreateParentResponse : WecomBaseResponse
{
    [JsonPropertyName("result")] public ParentCreateResult? Result { get; set; }
}

public record ParentCreateResult
{
    [JsonPropertyName("parent_userid")] public string? ParentUserid { get; init; }
    [JsonPropertyName("err_msg")] public string? ErrMsg { get; init; }
}

public record DeleteParentRequest
{
    [JsonPropertyName("parent_userid")] public string ParentUserid { get; init; } = string.Empty;
}

public class DeleteParentResponse : WecomBaseResponse
{
}

public record UpdateParentRequest
{
    [JsonPropertyName("parent_userid")] public string ParentUserid { get; init; } = string.Empty;
    [JsonPropertyName("name")] public string? Name { get; init; }
    [JsonPropertyName("department")] public int[]? Department { get; init; }
    [JsonPropertyName("mobile")] public string? Mobile { get; init; }
    [JsonPropertyName("children")] public ParentChildInfo? Children { get; init; }
}

public class UpdateParentResponse : WecomBaseResponse
{
}

public record BatchCreateParentRequest
{
    [JsonPropertyName("parents")] public ParentInfo[] Parents { get; init; } = [];
}

public class BatchCreateParentResponse : WecomBaseResponse
{
    [JsonPropertyName("result")] public ParentBatchResult[]? Result { get; set; }
}

public record BatchDeleteParentRequest
{
    [JsonPropertyName("parent_userids")] public string[] ParentUserids { get; init; } = [];
}

public class BatchDeleteParentResponse : WecomBaseResponse
{
    [JsonPropertyName("result")] public ParentBatchResult[]? Result { get; set; }
}

public record BatchUpdateParentRequest
{
    [JsonPropertyName("parents")] public ParentInfo[] Parents { get; init; } = [];
}

public class BatchUpdateParentResponse : WecomBaseResponse
{
    [JsonPropertyName("result")] public ParentBatchResult[]? Result { get; set; }
}

public record GetParentRequest
{
    [JsonPropertyName("parent_userid")] public string ParentUserid { get; init; } = string.Empty;
}

public class GetParentResponse : WecomBaseResponse
{
    [JsonPropertyName("parent_info")] public ParentInfo? ParentInfo { get; set; }
}
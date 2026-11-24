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
    [JsonPropertyName("errcode")] public int ErrCode { get; init; }
    [JsonPropertyName("errmsg")] public string? ErrMsg { get; init; }
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
    [JsonPropertyName("to_invite")] public bool? ToInvite { get; init; }
    [JsonPropertyName("new_parent_userid")] public string? NewParentUserid { get; init; }
}

public record CreateParentRequest
{
    [JsonPropertyName("parent_userid")] public string ParentUserid { get; init; } = string.Empty;
    [JsonPropertyName("mobile")] public string? Mobile { get; init; }
    [JsonPropertyName("to_invite")] public bool? ToInvite { get; init; }
    [JsonPropertyName("children")] public ParentChildInfo[]? ChildList { get; init; }
    [JsonIgnore] public ParentChildInfo? Children { get => ChildList?.FirstOrDefault(); init => ChildList = value is null ? null : [value]; }
    [Obsolete("创建家长接口不接收姓名。"), JsonIgnore] public string Name { get; init; } = string.Empty;
    [Obsolete("创建家长接口通过子女关联部门。"), JsonIgnore] public int[]? Department { get; init; }
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
    [JsonPropertyName("mobile")] public string? Mobile { get; init; }
    [JsonPropertyName("new_parent_userid")] public string? NewParentUserid { get; init; }
    [JsonPropertyName("children")] public ParentChildInfo[]? ChildList { get; init; }
    [JsonIgnore] public ParentChildInfo? Children { get => ChildList?.FirstOrDefault(); init => ChildList = value is null ? null : [value]; }
    [Obsolete("更新家长接口不接收姓名。"), JsonIgnore] public string? Name { get; init; }
    [Obsolete("更新家长接口通过子女关联部门。"), JsonIgnore] public int[]? Department { get; init; }
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
    [JsonPropertyName("result_list")] public ParentBatchResult[]? Result { get; set; }
}

public record BatchDeleteParentRequest
{
    [JsonPropertyName("useridlist")] public string[] ParentUserids { get; init; } = [];
}

public class BatchDeleteParentResponse : WecomBaseResponse
{
    [JsonPropertyName("result_list")] public ParentBatchResult[]? Result { get; set; }
}

public record BatchUpdateParentRequest
{
    [JsonPropertyName("parents")] public ParentInfo[] Parents { get; init; } = [];
}

public class BatchUpdateParentResponse : WecomBaseResponse
{
    [JsonPropertyName("result_list")] public ParentBatchResult[]? Result { get; set; }
}

public record GetParentRequest
{
    [JsonPropertyName("parent_userid")] public string ParentUserid { get; init; } = string.Empty;
}

public class GetParentResponse : WecomBaseResponse
{
    [JsonPropertyName("user_type")] public int UserType { get; set; }
    [JsonPropertyName("parent")] public ParentInfo? ParentInfo { get; set; }
}

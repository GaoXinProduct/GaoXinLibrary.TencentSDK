using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartDocument;

public enum SmartDocumentPublishRange : uint
{
    OrganizationOnly = 1,
    OrganizationAndExternal = 3,
    SelectedMembers = 4
}

public enum SmartDocumentAudienceMemberType : uint
{
    User = 1,
    Department = 2
}

public sealed class SmartDocumentAudienceMember
{
    [JsonPropertyName("type")] public required SmartDocumentAudienceMemberType Type { get; init; }
    [JsonPropertyName("userid")] public string? UserId { get; init; }
    [JsonPropertyName("departmentid")] public ulong? DepartmentId { get; init; }
}

public sealed class SmartDocumentPublishRequest
{
    [JsonPropertyName("docid")] public required string DocId { get; init; }

    /// <summary>发布可见范围。首次发布时默认企业内可见。</summary>
    [JsonPropertyName("publish_range")] public SmartDocumentPublishRange? PublishRange { get; init; }

    /// <summary>可查看的成员及部门。可见范围为指定成员时必填。</summary>
    [JsonPropertyName("auth_list")] public SmartDocumentAudienceMember[]? AuthList { get; init; }
}

public sealed class SmartDocumentPublishResponse : WecomBaseResponse
{
    [JsonPropertyName("share_code")] public string? ShareCode { get; init; }
    [JsonPropertyName("publish_url")] public string? PublishUrl { get; init; }
    [JsonPropertyName("version")] public ulong Version { get; init; }

    /// <summary>发布时间戳，单位为秒。</summary>
    [JsonPropertyName("publish_time")] public ulong PublishTime { get; init; }

    [JsonPropertyName("publish_doc_title")] public string? PublishDocTitle { get; init; }
}

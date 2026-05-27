using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.HomeSchool;

public record QrCodeRequest
{
    [JsonPropertyName("department_id")] public int DepartmentId { get; init; }
    [JsonPropertyName("qrcode_type")] public string? QrcodeType { get; init; }
    [JsonPropertyName("school_logo")] public int? SchoolLogo { get; init; }
}

public class QrCodeResponse : WecomBaseResponse
{
    [JsonPropertyName("qrcode_url")] public string? QrcodeUrl { get; set; }
}

public record SchoolNotificationRequest
{
    [JsonPropertyName("parent_userid")] public string? ParentUserid { get; init; }
    [JsonPropertyName("grade_id")] public int? GradeId { get; init; }
    [JsonPropertyName("class_id")] public int? ClassId { get; init; }
    [JsonPropertyName("msg_info")] public SchoolNotificationMsgInfo? MsgInfo { get; init; }
}

public record SchoolNotificationMsgInfo
{
    [JsonPropertyName("text")] public string? Text { get; init; }
    [JsonPropertyName("msg_type")] public string? MsgType { get; init; }
    [JsonPropertyName("media_id")] public string? MediaId { get; init; }
    [JsonPropertyName("link")] public SchoolNotificationLink? Link { get; init; }
}

public record SchoolNotificationLink
{
    [JsonPropertyName("title")] public string? Title { get; init; }
    [JsonPropertyName("desc")] public string? Desc { get; init; }
    [JsonPropertyName("url")] public string? Url { get; init; }
    [JsonPropertyName("cover_media_id")] public string? CoverMediaId { get; init; }
}

public class SchoolNotificationResponse : WecomBaseResponse
{
    [JsonPropertyName("msgid")] public string? Msgid { get; set; }
}

public record SchoolAttentionModeRequest
{
    [JsonPropertyName("parent_userid")] public string ParentUserid { get; init; } = string.Empty;
    [JsonPropertyName("subscribe_mode")] public string SubscribeMode { get; init; } = string.Empty;
}

public class SchoolAttentionModeResponse : WecomBaseResponse
{
}

public record ClassGroupCreationRequest
{
    [JsonPropertyName("grade_id")] public int GradeId { get; init; }
    [JsonPropertyName("class_id")] public int? ClassId { get; init; }
    [JsonPropertyName("create_mode")] public int CreateMode { get; init; }
}

public class ClassGroupCreationResponse : WecomBaseResponse
{
}

public record ExternalContactOpenIdRequest
{
    [JsonPropertyName("openid")] public string Openid { get; init; } = string.Empty;
    [JsonPropertyName("userid")] public string? Userid { get; init; }
}

public class ExternalContactOpenIdResponse : WecomBaseResponse
{
    [JsonPropertyName("corp_openid")] public string? CorpOpenid { get; set; }
}

public record ParentScopeRequest
{
    [JsonPropertyName("corp_id")] public string? CorpId { get; init; }
    [JsonPropertyName("school_corp_id")] public string? SchoolCorpId { get; init; }
    [JsonPropertyName("department_id")] public int? DepartmentId { get; init; }
}

public class ParentScopeResponse : WecomBaseResponse
{
    [JsonPropertyName("parent_userid_list")] public string[]? ParentUseridList { get; set; }
}
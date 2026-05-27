using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>导入会议报名信息请求</summary>
/// <remarks>doc path: /98816</remarks>
public record ImportRegistrationRequest
{
    /// <summary>会议ID</summary>
    [JsonPropertyName("meetingid")]
    public string MeetingId { get; init; } = string.Empty;

    /// <summary>用户userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; init; } = string.Empty;

    /// <summary>报名信息列表</summary>
    [JsonPropertyName("registration_list")]
    public List<ImportRegistrationItem>? RegistrationList { get; init; }
}

/// <summary>导入报名项</summary>
public class ImportRegistrationItem
{
    /// <summary>报名人名称</summary>
    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;

    /// <summary>报名人手机号</summary>
    [JsonPropertyName("phone")]
    public string? Phone { get; init; }

    /// <summary>报名人邮箱</summary>
    [JsonPropertyName("email")]
    public string? Email { get; init; }

    /// <summary>报名问题答案（JSON格式）</summary>
    [JsonPropertyName("answers")]
    public string? Answers { get; init; }
}
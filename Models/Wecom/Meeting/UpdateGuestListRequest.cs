using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>更新会议嘉宾列表请求</summary>
/// <remarks>doc path: /99040</remarks>
public record UpdateGuestListRequest
{
    /// <summary>会议ID</summary>
    [JsonPropertyName("meetingid")]
    public string MeetingId { get; init; } = string.Empty;

    /// <summary>用户userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; init; } = string.Empty;

    /// <summary>操作类型：1-添加，2-删除，3-清空</summary>
    [JsonPropertyName("operate_type")]
    public int OperateType { get; init; }

    /// <summary>嘉宾列表</summary>
    [JsonPropertyName("guests")]
    public List<GuestItem>? Guests { get; init; }
}

/// <summary>嘉宾项</summary>
public class GuestItem
{
    /// <summary>嘉宾名称</summary>
    [JsonPropertyName("guest_name")]
    public string GuestName { get; init; } = string.Empty;

    /// <summary>嘉宾手机号</summary>
    [JsonPropertyName("phone")]
    public string? Phone { get; init; }

    /// <summary>嘉宾邮箱</summary>
    [JsonPropertyName("email")]
    public string? Email { get; init; }
}
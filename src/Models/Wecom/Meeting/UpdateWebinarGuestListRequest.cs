using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>更新网络研讨会嘉宾列表请求</summary>
/// <remarks>doc path: /98872</remarks>
public record UpdateWebinarGuestListRequest
{
    /// <summary>研讨会ID</summary>
    [JsonPropertyName("webinar_id")]
    public string WebinarId { get; init; } = string.Empty;

    /// <summary>用户userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; init; } = string.Empty;

    /// <summary>操作类型：1-添加，2-删除，3-清空</summary>
    [JsonPropertyName("operate_type")]
    public int OperateType { get; init; }

    /// <summary>嘉宾userid列表</summary>
    [JsonPropertyName("guest_userids")]
    public List<string>? GuestUserIds { get; init; }
}
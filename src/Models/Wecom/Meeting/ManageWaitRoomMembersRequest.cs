using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>管理等候室成员请求</summary>
/// <remarks>doc path: /98186</remarks>
public record ManageWaitRoomMembersRequest
{
    /// <summary>会议ID</summary>
    [JsonPropertyName("meetingid")]
    public string MeetingId { get; init; } = string.Empty;

    /// <summary>用户userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; init; } = string.Empty;

    /// <summary>操作类型：1-允许入会，2-移出等候室</summary>
    [JsonPropertyName("operate_type")]
    public int OperateType { get; init; }

    /// <summary>成员userid列表</summary>
    [JsonPropertyName("userid_list")]
    public List<string>? UserIdList { get; init; }

    /// <summary>设备类型（用于外部联系人）：0-未知，1-Windows，2-macOS，3-iOS，4-Android，5-小程序，6-企业微信内置，7-H5</summary>
    [JsonPropertyName("device_type")]
    public int? DeviceType { get; init; }

    /// <summary>外部成员名称（当设备类型为外部联系人时使用）</summary>
    [JsonPropertyName("guest_name")]
    public string? GuestName { get; init; }
}
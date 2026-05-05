using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>更新会议受邀成员列表请求</summary>
/// <remarks>doc path: /98162</remarks>
public record UpdateMeetingInviteeListRequest
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

    /// <summary>受邀成员列表</summary>
    [JsonPropertyName("invitees")]
    public List<MeetingInvitee>? Invitees { get; init; }
}
using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>修改成员在会中显示的昵称请求</summary>
/// <remarks>doc path: /98188</remarks>
public record UpdateMemberNicknameRequest
{
    /// <summary>会议ID</summary>
    [JsonPropertyName("meetingid")]
    public string MeetingId { get; init; } = string.Empty;

    /// <summary>用户userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; init; } = string.Empty;

    /// <summary>被修改昵称的成员userid</summary>
    [JsonPropertyName("target_userid")]
    public string TargetUserId { get; init; } = string.Empty;

    /// <summary>新昵称</summary>
    [JsonPropertyName("nickname")]
    public string Nickname { get; init; } = string.Empty;
}
using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>静音成员请求</summary>
/// <remarks>doc path: /98184</remarks>
public record MuteMemberRequest
{
    /// <summary>会议ID</summary>
    [JsonPropertyName("meetingid")]
    public string MeetingId { get; init; } = string.Empty;

    /// <summary>用户userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; init; } = string.Empty;

    /// <summary>静音类型：1-静音，2-解除静音</summary>
    [JsonPropertyName("mute_type")]
    public int MuteType { get; init; }

    /// <summary>成员userid列表（为空则操作全体）</summary>
    [JsonPropertyName("userid_list")]
    public List<string>? UserIdList { get; init; }

    /// <summary>是否允许成员自己取消静音</summary>
    [JsonPropertyName("allow_unmute_by_self")]
    public bool? AllowUnmuteBySelf { get; init; }
}
using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>管理会中设置请求</summary>
/// <remarks>doc path: /98175</remarks>
public record ManageMeetingSettingsRequest
{
    /// <summary>会议ID</summary>
    [JsonPropertyName("meetingid")]
    public string MeetingId { get; init; } = string.Empty;

    /// <summary>用户userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; init; } = string.Empty;

    /// <summary>是否全员禁言</summary>
    [JsonPropertyName("mute_all")]
    public bool? MuteAll { get; init; }

    /// <summary>是否允许观众自行取消静音</summary>
    [JsonPropertyName("mute_all_allow_speak")]
    public bool? MuteAllAllowSpeak { get; init; }

    /// <summary>是否开启屏幕共享权限</summary>
    [JsonPropertyName("allow_screen_share")]
    public bool? AllowScreenShare { get; init; }

    /// <summary>是否允许观众发起弹幕消息</summary>
    [JsonPropertyName("allow_audience_danmaku")]
    public bool? AllowAudienceDanmaku { get; init; }

    /// <summary>是否允许主持人共享白板</summary>
    [JsonPropertyName("allow_whiteboard")]
    public bool? AllowWhiteboard { get; init; }

    /// <summary>是否开启直播</summary>
    [JsonPropertyName("enable_live")]
    public bool? EnableLive { get; init; }
}
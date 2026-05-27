using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>修改网络研讨会请求</summary>
/// <remarks>doc path: /98843</remarks>
public record ModifyWebinarRequest
{
    /// <summary>研讨会ID</summary>
    [JsonPropertyName("webinar_id")]
    public string WebinarId { get; init; } = string.Empty;

    /// <summary>用户userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; init; } = string.Empty;

    /// <summary>研讨会标题</summary>
    [JsonPropertyName("subject")]
    public string? Subject { get; init; }

    /// <summary>研讨会开始时间（Unix 时间戳，秒）</summary>
    [JsonPropertyName("webinar_start")]
    public long? WebinarStart { get; init; }

    /// <summary>研讨会结束时间（Unix 时间戳，秒）</summary>
    [JsonPropertyName("webinar_end")]
    public long? WebinarEnd { get; init; }

    /// <summary>研讨会描述</summary>
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    /// <summary>是否开启直播</summary>
    [JsonPropertyName("enable_live")]
    public bool? EnableLive { get; init; }

    /// <summary>是否开启报名</summary>
    [JsonPropertyName("enable_registration")]
    public bool? EnableRegistration { get; init; }

    /// <summary>是否开启观众观看时禁止发送聊天消息</summary>
    [JsonPropertyName("mute_all_allow_speak")]
    public bool? MuteAllAllowSpeak { get; init; }

    /// <summary>是否允许观众发起弹幕消息</summary>
    [JsonPropertyName("allow_audience_danmaku")]
    public bool? AllowAudienceDanmaku { get; init; }

    /// <summary>是否允许主持人共享白板</summary>
    [JsonPropertyName("allow_whiteboard")]
    public bool? AllowWhiteboard { get; init; }

    /// <summary>是否开启联席主持人</summary>
    [JsonPropertyName("enable_cohost")]
    public bool? EnableCohost { get; init; }

    /// <summary>研讨会地点</summary>
    [JsonPropertyName("location")]
    public string? Location { get; init; }
}
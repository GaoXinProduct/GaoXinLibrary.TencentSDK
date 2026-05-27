using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>修改预约会议请求</summary>
/// <remarks>doc path: /98154</remarks>
public record ModifyAdvancedMeetingRequest
{
    /// <summary>会议ID</summary>
    [JsonPropertyName("meetingid")]
    public string MeetingId { get; init; } = string.Empty;

    /// <summary>用户userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; init; } = string.Empty;

    /// <summary>会议标题</summary>
    [JsonPropertyName("title")]
    public string? Title { get; init; }

    /// <summary>会议开始时间（Unix 时间戳，秒）</summary>
    [JsonPropertyName("meeting_start")]
    public long? MeetingStart { get; init; }

    /// <summary>会议结束时间（Unix 时间戳，秒）</summary>
    [JsonPropertyName("meeting_end")]
    public long? MeetingEnd { get; init; }

    /// <summary>会议描述</summary>
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    /// <summary>是否开启直播</summary>
    [JsonPropertyName("enable_live")]
    public bool? EnableLive { get; init; }

    /// <summary>是否开启等候室</summary>
    [JsonPropertyName("enable_waiting_room")]
    public bool? EnableWaitingRoom { get; init; }

    /// <summary>是否开启联席主持人</summary>
    [JsonPropertyName("enable_cohost")]
    public bool? EnableCohost { get; init; }

    /// <summary>是否开启屏幕共享权限</summary>
    [JsonPropertyName("allow_screen_share")]
    public bool? AllowScreenShare { get; init; }

    /// <summary>是否开启与会者发起弹幕消息</summary>
    [JsonPropertyName("allow_audience_danmaku")]
    public bool? AllowAudienceDanmaku { get; init; }

    /// <summary>是否允许主持人共享白板</summary>
    [JsonPropertyName("allow_whiteboard")]
    public bool? AllowWhiteboard { get; init; }

    /// <summary>入会限制：0-不限制，1-仅企业成员，2-仅被邀请者</summary>
    [JsonPropertyName("join_approval_type")]
    public int? JoinApprovalType { get; init; }

    /// <summary>是否开启主持人未入会时允许其他参会者先入会</summary>
    [JsonPropertyName("enable_host_enter_before")]
    public bool? EnableHostEnterBefore { get; init; }

    /// <summary>是否开启仅验证手机号入会</summary>
    [JsonPropertyName("only_allow_mobile")]
    public bool? OnlyAllowMobile { get; init; }

    /// <summary>是否开启观众观看时禁止发送聊天消息</summary>
    [JsonPropertyName("mute_all_allow_speak")]
    public bool? MuteAllAllowSpeak { get; init; }

    /// <summary>是否开启会议主持人选择观众发言</summary>
    [JsonPropertyName("mute_audience")]
    public bool? MuteAudience { get; init; }

    /// <summary>录制配置：0-不录制，1-自动录制，2-手动录制</summary>
    [JsonPropertyName("record_setting")]
    public int? RecordSetting { get; init; }

    /// <summary>是否全员禁言</summary>
    [JsonPropertyName("mute_all")]
    public bool? MuteAll { get; init; }

    /// <summary>会议密码</summary>
    [JsonPropertyName("password")]
    public string? Password { get; init; }

    /// <summary>会议地点</summary>
    [JsonPropertyName("location")]
    public string? Location { get; init; }
}
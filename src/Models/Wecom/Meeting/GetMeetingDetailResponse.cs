using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取会议详情响应</summary>
/// <remarks>doc path: /99049</remarks>
public class GetMeetingDetailResponse : WecomBaseResponse
{
    /// <summary>会议信息</summary>
    [JsonPropertyName("meeting_info")]
    public MeetingDetailInfo? MeetingInfo { get; set; }
}

/// <summary>会议详情信息</summary>
public class MeetingDetailInfo
{
    /// <summary>会议ID</summary>
    [JsonPropertyName("meetingid")]
    public string? MeetingId { get; set; }

    /// <summary>会议号</summary>
    [JsonPropertyName("meeting_code")]
    public string? MeetingCode { get; set; }

    /// <summary>会议标题</summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <summary>会议开始时间（Unix 时间戳，秒）</summary>
    [JsonPropertyName("meeting_start")]
    public long MeetingStart { get; set; }

    /// <summary>会议结束时间（Unix 时间戳，秒）</summary>
    [JsonPropertyName("meeting_end")]
    public long MeetingEnd { get; set; }

    /// <summary>会议状态：0-未开始，1-正在进行，2-已结束，3-已取消</summary>
    [JsonPropertyName("status")]
    public int Status { get; set; }

    /// <summary>会议类型：0-普通会议，1-全员会议</summary>
    [JsonPropertyName("meeting_type")]
    public int MeetingType { get; set; }

    /// <summary>会议描述</summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>组织名称</summary>
    [JsonPropertyName("org_name")]
    public string? OrgName { get; set; }

    /// <summary>会议主持人userid</summary>
    [JsonPropertyName("host_userid")]
    public string? HostUserId { get; set; }

    /// <summary>直播链接</summary>
    [JsonPropertyName("live_url")]
    public string? LiveUrl { get; set; }

    /// <summary>入会链接</summary>
    [JsonPropertyName("join_url")]
    public string? JoinUrl { get; set; }

    /// <summary>会议密码</summary>
    [JsonPropertyName("password")]
    public string? Password { get; set; }

    /// <summary>会议设置</summary>
    [JsonPropertyName("settings")]
    public MeetingSettings? Settings { get; set; }

    /// <summary>是否自动开始录制</summary>
    [JsonPropertyName("auto_record")]
    public bool AutoRecord { get; set; }
}

/// <summary>会议设置</summary>
public class MeetingSettings
{
    /// <summary>是否开启全员观看时禁止举手</summary>
    [JsonPropertyName("mute_all")]
    public bool? MuteAll { get; set; }

    /// <summary>是否开启观众观看时禁止发送聊天消息</summary>
    [JsonPropertyName("mute_all_allow_speak")]
    public bool? MuteAllAllowSpeak { get; set; }

    /// <summary>是否开启会议主持人选择观众发言</summary>
    [JsonPropertyName("mute_audience")]
    public bool? MuteAudience { get; set; }

    /// <summary>是否开启屏幕共享权限</summary>
    [JsonPropertyName("allow_screen_share")]
    public bool? AllowScreenShare { get; set; }

    /// <summary>是否开启与会者发起弹幕消息</summary>
    [JsonPropertyName("allow_audience_danmaku")]
    public bool? AllowAudienceDanmaku { get; set; }

    /// <summary>是否允许主持人共享白板</summary>
    [JsonPropertyName("allow_whiteboard")]
    public bool? AllowWhiteboard { get; set; }

    /// <summary>是否开启直播</summary>
    [JsonPropertyName("enable_live")]
    public bool? EnableLive { get; set; }

    /// <summary>是否开启主持人未入会时允许其他参会者先入会</summary>
    [JsonPropertyName("enable_host_enter_before")]
    public bool? EnableHostEnterBefore { get; set; }

    /// <summary>是否开启联席主持人</summary>
    [JsonPropertyName("enable_cohost")]
    public bool? EnableCohost { get; set; }

    /// <summary>入会限制：0-不限制，1-仅企业成员，2-仅被邀请者</summary>
    [JsonPropertyName("join_approval_type")]
    public int? JoinApprovalType { get; set; }

    /// <summary>是否开启等候室</summary>
    [JsonPropertyName("enable_waiting_room")]
    public bool? EnableWaitingRoom { get; set; }

    /// <summary>是否开启仅验证手机号入会</summary>
    [JsonPropertyName("only_allow_mobile")]
    public bool? OnlyAllowMobile { get; set; }

    /// <summary>录制配置：0-不录制，1-自动录制，2-手动录制</summary>
    [JsonPropertyName("record_setting")]
    public int? RecordSetting { get; set; }
}
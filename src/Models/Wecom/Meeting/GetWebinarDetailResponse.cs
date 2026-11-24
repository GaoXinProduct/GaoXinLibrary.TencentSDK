using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取网络研讨会详情响应</summary>
/// <remarks>doc path: /98860</remarks>
public class GetWebinarDetailResponse : WecomBaseResponse
{
    /// <summary>研讨会信息</summary>
    [JsonPropertyName("webinar_info")]
    public WebinarDetailInfo? WebinarInfo { get; set; }
}

/// <summary>网络研讨会详情信息</summary>
public class WebinarDetailInfo : WecomBaseResponse
{
    /// <summary>研讨会ID</summary>
    [JsonPropertyName("meetingid")]
    public string? WebinarId { get; set; }

    /// <summary>研讨会号</summary>
    [JsonPropertyName("meeting_code")]
    public string? WebinarCode { get; set; }

    /// <summary>研讨会标题</summary>
    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

    /// <summary>研讨会开始时间（Unix 时间戳，秒）</summary>
    [JsonPropertyName("start_time")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public long WebinarStart { get; set; }

    /// <summary>研讨会结束时间（Unix 时间戳，秒）</summary>
    [JsonPropertyName("end_time")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public long WebinarEnd { get; set; }

    [Obsolete("请使用 State 获取企业微信返回的会议状态。")]
    [JsonIgnore]
    public int Status { get; set; }

    /// <summary>研讨会状态，例如 MEETING_STATE_STARTED。</summary>
    [JsonPropertyName("status")]
    public string? State { get; set; }

    /// <summary>研讨会描述</summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>组织名称</summary>
    [JsonPropertyName("sponsor")]
    public string? OrgName { get; set; }

    /// <summary>主持人userid</summary>
    [JsonPropertyName("userid")]
    public string? HostUserId { get; set; }

    /// <summary>直播链接</summary>
    [JsonPropertyName("live_url")]
    public string? LiveUrl { get; set; }

    /// <summary>入会链接</summary>
    [JsonPropertyName("audience_join_link")]
    public string? JoinUrl { get; set; }

    /// <summary>研讨会地点</summary>
    [JsonPropertyName("location")]
    public string? Location { get; set; }

    /// <summary>是否开启直播</summary>
    [JsonPropertyName("enable_live")]
    public bool EnableLive { get; set; }

    /// <summary>是否开启报名</summary>
    [JsonPropertyName("enable_registration")]
    public bool EnableRegistration { get; set; }

    /// <summary>是否开启联席主持人</summary>
    [JsonPropertyName("enable_cohost")]
    public bool EnableCohost { get; set; }

    [JsonPropertyName("admission_type")] public int AdmissionType { get; set; }
    [JsonPropertyName("hosts")] public WebinarHost[]? Hosts { get; set; }
    [JsonPropertyName("password")] public string? Password { get; set; }
    [JsonPropertyName("cover_url")] public string? CoverUrl { get; set; }
    [JsonPropertyName("enable_guest_invite_link")] public bool? EnableGuestInviteLink { get; set; }
    [JsonPropertyName("guest_join_link")] public string? GuestJoinUrl { get; set; }
    [JsonPropertyName("media_setting")] public WebinarMediaSettings? MediaSetting { get; set; }
    [JsonPropertyName("enable_qa")] public bool? EnableQa { get; set; }
    [JsonPropertyName("manual_check_link")] public string? ManualCheckUrl { get; set; }
    [JsonPropertyName("manual_check_password")] public string? ManualCheckPassword { get; set; }
    [JsonPropertyName("activity_page")] public bool? ActivityPage { get; set; }
    [JsonPropertyName("display_number_of_participants")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public int? DisplayParticipantCount { get; set; }
    [JsonPropertyName("playback_for_audience")] public bool? PlaybackForAudience { get; set; }
    [JsonPropertyName("playback_url")] public string? PlaybackUrl { get; set; }
    [JsonPropertyName("sync_to_wework")] public bool? SyncToWeWork { get; set; }
    [JsonPropertyName("preparation_mode")] public bool? PreparationMode { get; set; }
    [JsonPropertyName("warm_up_picture")] public string? WarmUpPicture { get; set; }
    [JsonPropertyName("warm_up_video")] public string? WarmUpVideo { get; set; }
    [JsonPropertyName("allow_participants_invite_others")] public bool? AllowParticipantsInviteOthers { get; set; }
}

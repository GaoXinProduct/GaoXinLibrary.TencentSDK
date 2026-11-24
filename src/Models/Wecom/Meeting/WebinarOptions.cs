namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>网络研讨会的创建和修改选项。</summary>
public abstract record WebinarOptions
{
    private int? _admissionType;

    [JsonPropertyName("sponsor")] public string? OrgName { get; init; }
    [JsonPropertyName("description")] public string? Description { get; init; }

    /// <summary>观众观看限制。0 公开，1 报名，2 密码。</summary>
    [JsonPropertyName("admission_type")]
    public int AdmissionType
    {
        get => _admissionType ?? (EnableRegistration == true ? 1 : 0);
        init => _admissionType = value;
    }

    /// <summary>未指定 <see cref="AdmissionType"/> 时，可通过此属性启用报名。</summary>
    [JsonIgnore]
    public bool? EnableRegistration { get; init; }

    [JsonPropertyName("hosts")] public WebinarHost[]? Hosts { get; init; }
    [JsonPropertyName("password")] public string? Password { get; init; }
    [JsonPropertyName("cover_url")] public string? CoverUrl { get; init; }
    [JsonPropertyName("enable_guest_invite_link")] public bool? EnableGuestInviteLink { get; init; }
    [JsonPropertyName("media_setting")] public WebinarMediaSettings? MediaSetting { get; init; }
    [JsonPropertyName("enable_qa")] public bool? EnableQa { get; init; }
    [JsonPropertyName("sensitive_words")] public string[]? SensitiveWords { get; init; }
    [JsonPropertyName("enable_manual_check")] public bool? EnableManualCheck { get; init; }
    [JsonPropertyName("activity_page")] public bool? ActivityPage { get; init; }
    [JsonPropertyName("display_number_of_participants")] public int? DisplayParticipantCount { get; init; }
    [JsonPropertyName("playback_for_audience")] public bool PlaybackForAudience { get; init; }
    [JsonPropertyName("preparation_mode")] public bool? PreparationMode { get; init; }

    [Obsolete("网络研讨会接口不支持 enable_live。")]
    [JsonIgnore]
    public bool? EnableLive { get; init; }

    [Obsolete("网络研讨会接口不支持 mute_all_allow_speak。")]
    [JsonIgnore]
    public bool? MuteAllAllowSpeak { get; init; }

    [Obsolete("网络研讨会接口不支持 allow_audience_danmaku。")]
    [JsonIgnore]
    public bool? AllowAudienceDanmaku { get; init; }

    [Obsolete("网络研讨会接口不支持 allow_whiteboard。")]
    [JsonIgnore]
    public bool? AllowWhiteboard { get; init; }

    [Obsolete("请使用 Hosts 设置主持人。")]
    [JsonIgnore]
    public bool? EnableCohost { get; init; }

    [Obsolete("网络研讨会接口不支持 location。")]
    [JsonIgnore]
    public string? Location { get; init; }
}

/// <summary>网络研讨会主持人。</summary>
public sealed class WebinarHost
{
    [JsonPropertyName("userid")] public string? UserId { get; set; }
    [JsonPropertyName("open_id")] public string? OpenId { get; set; }
}

/// <summary>网络研讨会媒体配置。</summary>
public sealed class WebinarMediaSettings
{
    [JsonPropertyName("mute_enable_join")] public bool? MuteOnJoin { get; set; }
    [JsonPropertyName("allow_unmute_self")] public bool? AllowUnmuteSelf { get; set; }
    [JsonPropertyName("allow_in_before_host")] public bool? AllowEnterBeforeHost { get; set; }
    [JsonPropertyName("allow_screen_shared_watermark")] public bool? AllowScreenSharedWatermark { get; set; }
    [JsonPropertyName("water_mark_type")] public int? WatermarkType { get; set; }
    [JsonPropertyName("only_enterprise_user_allowed")] public bool? OnlyEnterpriseUsersAllowed { get; set; }
    [JsonPropertyName("auto_record_type")] public string? AutoRecordType { get; set; }
    [JsonPropertyName("participant_join_auto_record")] public bool? ParticipantJoinAutoRecord { get; set; }
    [JsonPropertyName("enable_host_pause_auto_record")] public bool? EnableHostPauseAutoRecord { get; set; }
}

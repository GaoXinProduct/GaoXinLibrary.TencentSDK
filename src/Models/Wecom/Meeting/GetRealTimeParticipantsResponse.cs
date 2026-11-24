using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取实时会中成员列表响应</summary>
/// <remarks>doc path: /98157</remarks>
public class GetRealTimeParticipantsResponse : WecomBaseResponse
{
    /// <summary>会中成员列表</summary>
    [JsonPropertyName("attendees")]
    public List<ParticipantInfo>? Participants { get; set; }

    /// <summary>会议状态。</summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>旧版响应属性。实时会中成员接口不返回会议总人数。</summary>
    [Obsolete("实时会中成员接口不返回会议总人数，请使用 Participants 获取当前页。")]
    [JsonPropertyName("participant_count")]
    public int ParticipantCount { get; set; }

    /// <summary>分页游标</summary>
    [JsonPropertyName("next_cursor")]
    public string? NextCursor { get; set; }

    /// <summary>是否还有更多数据</summary>
    [JsonPropertyName("has_more")]
    public bool HasMore { get; set; }
}

/// <summary>参会者信息</summary>
public class ParticipantInfo
{
    private bool? _isHost;
    private bool? _isCohost;
    private bool? _isMuted;

    /// <summary>用户userid</summary>
    [JsonPropertyName("userid")]
    public string? UserId { get; set; }

    /// <summary>会中成员的临时 ID。</summary>
    [JsonPropertyName("tmp_openid")]
    public string? TemporaryOpenId { get; set; }

    /// <summary>用户名</summary>
    [JsonPropertyName("username")]
    public string? Username { get; set; }

    /// <summary>成员类型：0-内部成员，1-外部成员，2-PSTN用户，3-匿名用户</summary>
    [JsonPropertyName("member_type")]
    public int MemberType { get; set; }

    /// <summary>入会时间（Unix 时间戳，秒）</summary>
    [JsonPropertyName("join_time")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public long JoinTime { get; set; }

    /// <summary>成员终端设备类型。</summary>
    [JsonPropertyName("instance_id")]
    public int InstanceId { get; set; }

    /// <summary>会中角色。0 普通成员，1 创建者，2 主持人，3 创建者兼主持人，4 游客，5 游客兼主持人，6 联席主持人，7 创建者兼联席主持人。</summary>
    [JsonPropertyName("role")]
    public int Role { get; set; }

    /// <summary>入会方式。</summary>
    [JsonPropertyName("join_type")]
    public int JoinType { get; set; }

    /// <summary>是否开启麦克风。</summary>
    [JsonPropertyName("audio_state")]
    public bool? AudioState { get; set; }

    /// <summary>是否开启摄像头。</summary>
    [JsonPropertyName("video_state")]
    public bool VideoState { get; set; }

    /// <summary>是否开启屏幕共享。</summary>
    [JsonPropertyName("screen_shared_state")]
    public bool ScreenSharedState { get; set; }

    /// <summary>参会时长（秒）</summary>
    [JsonPropertyName("duration")]
    public long Duration { get; set; }

    /// <summary>是否为主持人</summary>
    [JsonPropertyName("is_host")]
    public bool IsHost
    {
        get => _isHost ?? Role is 2 or 3 or 5;
        set => _isHost = value;
    }

    /// <summary>是否为联席主持人</summary>
    [JsonPropertyName("is_cohost")]
    public bool IsCohost
    {
        get => _isCohost ?? Role is 6 or 7;
        set => _isCohost = value;
    }

    /// <summary>是否静音</summary>
    [JsonPropertyName("is_muted")]
    public bool IsMuted
    {
        get => _isMuted ?? AudioState == false;
        set => _isMuted = value;
    }

    /// <summary>是否开启视频</summary>
    [JsonPropertyName("is_video_on")]
    public bool IsVideoOn
    {
        get => VideoState;
        set => VideoState = value;
    }

    /// <summary>是否在屏幕共享</summary>
    [JsonPropertyName("is_screen_sharing")]
    public bool IsScreenSharing
    {
        get => ScreenSharedState;
        set => ScreenSharedState = value;
    }

    /// <summary>是否在等候室</summary>
    [JsonPropertyName("is_in_waiting_room")]
    public bool IsInWaitingRoom { get; set; }

    /// <summary>设备类型：0-未知，1-Windows，2-macOS，3-iOS，4-Android，5-小程序，6-企业微信内置，7-H5</summary>
    [JsonPropertyName("device_type")]
    public int DeviceType { get; set; }

    /// <summary>房间信息</summary>
    [JsonPropertyName("room_info")]
    public ParticipantRoomInfo? RoomInfo { get; set; }
}

/// <summary>参会者房间信息</summary>
public class ParticipantRoomInfo
{
    /// <summary>房间ID</summary>
    [JsonPropertyName("room_id")]
    public string? RoomId { get; set; }

    /// <summary>房间名称</summary>
    [JsonPropertyName("room_name")]
    public string? RoomName { get; set; }
}

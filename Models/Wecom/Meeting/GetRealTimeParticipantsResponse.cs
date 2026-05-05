using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取实时会中成员列表响应</summary>
/// <remarks>doc path: /98157</remarks>
public class GetRealTimeParticipantsResponse : WecomBaseResponse
{
    /// <summary>会中成员列表</summary>
    [JsonPropertyName("participants")]
    public List<ParticipantInfo>? Participants { get; set; }

    /// <summary>当前会议人数</summary>
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
    /// <summary>用户userid</summary>
    [JsonPropertyName("userid")]
    public string? UserId { get; set; }

    /// <summary>用户名</summary>
    [JsonPropertyName("username")]
    public string? Username { get; set; }

    /// <summary>成员类型：0-内部成员，1-外部成员，2-PSTN用户，3-匿名用户</summary>
    [JsonPropertyName("member_type")]
    public int MemberType { get; set; }

    /// <summary>入会时间（Unix 时间戳，秒）</summary>
    [JsonPropertyName("join_time")]
    public long JoinTime { get; set; }

    /// <summary>参会时长（秒）</summary>
    [JsonPropertyName("duration")]
    public long Duration { get; set; }

    /// <summary>是否为主持人</summary>
    [JsonPropertyName("is_host")]
    public bool IsHost { get; set; }

    /// <summary>是否为联席主持人</summary>
    [JsonPropertyName("is_cohost")]
    public bool IsCohost { get; set; }

    /// <summary>是否静音</summary>
    [JsonPropertyName("is_muted")]
    public bool IsMuted { get; set; }

    /// <summary>是否开启视频</summary>
    [JsonPropertyName("is_video_on")]
    public bool IsVideoOn { get; set; }

    /// <summary>是否在屏幕共享</summary>
    [JsonPropertyName("is_screen_sharing")]
    public bool IsScreenSharing { get; set; }

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
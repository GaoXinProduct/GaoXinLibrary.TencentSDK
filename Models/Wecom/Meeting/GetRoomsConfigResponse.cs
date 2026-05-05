using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取Rooms会议室配置项响应</summary>
/// <remarks>doc path: /98802</remarks>
public class GetRoomsConfigResponse : WecomBaseResponse
{
    /// <summary>会议室配置</summary>
    [JsonPropertyName("room_config")]
    public RoomsConfigInfo? RoomConfig { get; set; }
}

/// <summary>会议室配置信息</summary>
public class RoomsConfigInfo
{
    /// <summary>会议室ID</summary>
    [JsonPropertyName("room_id")]
    public string? RoomId { get; set; }

    /// <summary>默认布局ID</summary>
    [JsonPropertyName("default_layout_id")]
    public string? DefaultLayoutId { get; set; }

    /// <summary>默认背景ID</summary>
    [JsonPropertyName("default_background_id")]
    public string? DefaultBackgroundId { get; set; }

    /// <summary>会议自动延长时长（分钟）</summary>
    [JsonPropertyName("auto_extend_duration")]
    public int AutoExtendDuration { get; set; }

    /// <summary>是否显示日程</summary>
    [JsonPropertyName("show_schedule")]
    public bool ShowSchedule { get; set; }

    /// <summary>是否启用等候室</summary>
    [JsonPropertyName("enable_waiting_room")]
    public bool EnableWaitingRoom { get; set; }

    /// <summary>入会方式：1-仅主持人，2-所有成员</summary>
    [JsonPropertyName("join_meeting_as")]
    public int? JoinMeetingAs { get; set; }
}
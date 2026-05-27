using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取MRA状态信息响应</summary>
/// <remarks>doc path: /98786</remarks>
public class GetMRAStatusResponse : WecomBaseResponse
{
    /// <summary>MRA状态信息</summary>
    [JsonPropertyName("mra_status")]
    public MRAStatusInfo? MraStatus { get; set; }
}

/// <summary>MRA状态信息</summary>
public class MRAStatusInfo
{
    /// <summary>设备serial</summary>
    [JsonPropertyName("device_serial")]
    public string? DeviceSerial { get; set; }

    /// <summary>设备状态：0-未知，1-空闲，2-来电提示，3-通话中，4-呼叫中</summary>
    [JsonPropertyName("status")]
    public int Status { get; set; }

    /// <summary>会议ID（如果正在会议中）</summary>
    [JsonPropertyName("meetingid")]
    public string? MeetingId { get; set; }

    /// <summary>会议室名称</summary>
    [JsonPropertyName("room_name")]
    public string? RoomName { get; set; }

    /// <summary>是否在会议中</summary>
    [JsonPropertyName("is_in_meeting")]
    public bool IsInMeeting { get; set; }
}
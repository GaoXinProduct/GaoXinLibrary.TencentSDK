using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取Rooms会议室详情响应</summary>
/// <remarks>doc path: /98793</remarks>
public class GetRoomsDetailResponse : WecomBaseResponse
{
    /// <summary>会议室详情</summary>
    [JsonPropertyName("room_detail")]
    public RoomDetailInfo? RoomDetail { get; set; }
}

/// <summary>会议室详情信息</summary>
public class RoomDetailInfo
{
    /// <summary>会议室ID</summary>
    [JsonPropertyName("room_id")]
    public string? RoomId { get; set; }

    /// <summary>会议室名称</summary>
    [JsonPropertyName("room_name")]
    public string? RoomName { get; set; }

    /// <summary>会议室类型：1-小型，2-中型，3-大型，4-大型（配套）</summary>
    [JsonPropertyName("room_type")]
    public int RoomType { get; set; }

    /// <summary>会议室位置</summary>
    [JsonPropertyName("location")]
    public string? Location { get; set; }

    /// <summary>设备数量</summary>
    [JsonPropertyName("device_num")]
    public int DeviceNum { get; set; }

    /// <summary>状态：0-未知，1-空闲，2-使用中，3-不可用</summary>
    [JsonPropertyName("status")]
    public int Status { get; set; }

    /// <summary>设备列表</summary>
    [JsonPropertyName("devices")]
    public List<RoomDeviceInfo>? Devices { get; set; }
}

/// <summary>会议室设备信息</summary>
public class RoomDeviceInfo
{
    /// <summary>设备ID</summary>
    [JsonPropertyName("device_id")]
    public string? DeviceId { get; set; }

    /// <summary>设备名称</summary>
    [JsonPropertyName("device_name")]
    public string? DeviceName { get; set; }

    /// <summary>设备类型：1-会议大屏，2-白板，3-空调，4-灯，5-窗帘</summary>
    [JsonPropertyName("device_type")]
    public int DeviceType { get; set; }

    /// <summary>设备状态：0-未知，1-在线，2-离线</summary>
    [JsonPropertyName("status")]
    public int Status { get; set; }
}
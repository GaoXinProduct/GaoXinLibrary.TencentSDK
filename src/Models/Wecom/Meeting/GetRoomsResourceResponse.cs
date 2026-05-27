using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取Rooms会议室资源响应</summary>
/// <remarks>doc path: /98809</remarks>
public class GetRoomsResourceResponse : WecomBaseResponse
{
    /// <summary>会议室资源信息</summary>
    [JsonPropertyName("room_resource")]
    public RoomsResourceInfo? RoomResource { get; set; }
}

/// <summary>会议室资源信息</summary>
public class RoomsResourceInfo
{
    /// <summary>会议室ID</summary>
    [JsonPropertyName("room_id")]
    public string? RoomId { get; set; }

    /// <summary>存储总量（字节）</summary>
    [JsonPropertyName("total_storage")]
    public long TotalStorage { get; set; }

    /// <summary>已用存储（字节）</summary>
    [JsonPropertyName("used_storage")]
    public long UsedStorage { get; set; }

    /// <summary>最大录制时长（秒）</summary>
    [JsonPropertyName("max_recording_duration")]
    public long MaxRecordingDuration { get; set; }

    /// <summary>已用录制时长（秒）</summary>
    [JsonPropertyName("used_recording_duration")]
    public long UsedRecordingDuration { get; set; }
}
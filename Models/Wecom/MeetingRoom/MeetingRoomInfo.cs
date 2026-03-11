using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.MeetingRoom;

/// <summary>会议室信息</summary>
public class MeetingRoomInfo
{
    /// <summary>会议室ID</summary>
    [JsonPropertyName("meetingroom_id")] public int MeetingRoomId { get; set; }

    /// <summary>会议室名称</summary>
    [JsonPropertyName("name")] public string? Name { get; set; }

    /// <summary>会议室容纳人数</summary>
    [JsonPropertyName("capacity")] public int Capacity { get; set; }

    /// <summary>会议室所在城市</summary>
    [JsonPropertyName("city")] public string? City { get; set; }

    /// <summary>会议室所在楼层</summary>
    [JsonPropertyName("floor")] public string? Floor { get; set; }

    /// <summary>会议室所在建筑</summary>
    [JsonPropertyName("building")] public string? Building { get; set; }

    /// <summary>是否有设备：TV</summary>
    [JsonPropertyName("equipment")] public int[]? Equipment { get; set; }
}

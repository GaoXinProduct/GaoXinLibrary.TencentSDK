using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取Rooms会议室列表响应</summary>
/// <remarks>doc path: /98795</remarks>
public class GetRoomsListResponse : WecomBaseResponse
{
    /// <summary>会议室列表</summary>
    [JsonPropertyName("rooms")]
    public List<RoomInfo>? Rooms { get; set; }

    /// <summary>分页游标</summary>
    [JsonPropertyName("next_cursor")]
    public string? NextCursor { get; set; }

    /// <summary>是否还有更多数据</summary>
    [JsonPropertyName("has_more")]
    public bool HasMore { get; set; }
}

/// <summary>会议室信息</summary>
public class RoomInfo
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
}
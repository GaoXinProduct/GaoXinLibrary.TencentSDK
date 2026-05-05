using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>释放Rooms会议室响应</summary>
/// <remarks>doc path: /98792</remarks>
public class ReleaseRoomsResponse : WecomBaseResponse
{
    /// <summary>会议室释放列表</summary>
    [JsonPropertyName("room_release_list")]
    public List<RoomReleaseInfo>? RoomReleaseList { get; set; }
}

/// <summary>会议室释放信息</summary>
public class RoomReleaseInfo
{
    /// <summary>会议室ID</summary>
    [JsonPropertyName("room_id")]
    public string? RoomId { get; set; }

    /// <summary>是否释放成功</summary>
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    /// <summary>错误码</summary>
    [JsonPropertyName("errcode")]
    public int ErrCode { get; set; }

    /// <summary>错误信息</summary>
    [JsonPropertyName("errmsg")]
    public string? ErrMsg { get; set; }
}
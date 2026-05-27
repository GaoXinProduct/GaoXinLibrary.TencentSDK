using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>预定Rooms会议室响应</summary>
/// <remarks>doc path: /98791</remarks>
public class ReserveRoomsResponse : WecomBaseResponse
{
    /// <summary>会议室预订列表</summary>
    [JsonPropertyName("room_book_list")]
    public List<RoomBookInfo>? RoomBookList { get; set; }
}

/// <summary>会议室预订信息</summary>
public class RoomBookInfo
{
    /// <summary>会议室ID</summary>
    [JsonPropertyName("room_id")]
    public string? RoomId { get; set; }

    /// <summary>是否预订成功</summary>
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    /// <summary>错误码</summary>
    [JsonPropertyName("errcode")]
    public int ErrCode { get; set; }

    /// <summary>错误信息</summary>
    [JsonPropertyName("errmsg")]
    public string? ErrMsg { get; set; }
}
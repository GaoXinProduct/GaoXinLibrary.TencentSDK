using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.MeetingRoom;

/// <summary>获取会议室预定信息请求</summary>
public class GetBookingInfoRequest
{
    /// <summary>会议室 ID</summary>
    [JsonPropertyName("meetingroom_id")]
    public int MeetingRoomId { get; set; }

    /// <summary>查询开始时间（Unix 时间戳，秒）</summary>
    [JsonPropertyName("start_time")]
    public long StartTime { get; set; }

    /// <summary>查询结束时间（Unix 时间戳，秒）</summary>
    [JsonPropertyName("end_time")]
    public long EndTime { get; set; }
}

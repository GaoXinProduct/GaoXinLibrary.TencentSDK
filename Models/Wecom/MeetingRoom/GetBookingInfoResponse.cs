using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.MeetingRoom;

/// <summary>获取预定信息响应</summary>
public class GetBookingInfoResponse : WecomBaseResponse
{
    /// <summary>预定信息列表</summary>
    [JsonPropertyName("booking_list")] public BookingInfo[]? BookingList { get; set; }
}

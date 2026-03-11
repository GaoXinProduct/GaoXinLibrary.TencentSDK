using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.MeetingRoom;

/// <summary>获取会议室列表响应</summary>
public class GetMeetingRoomListResponse : WecomBaseResponse
{
    /// <summary>会议室列表</summary>
    [JsonPropertyName("meetingroom_list")] public MeetingRoomInfo[]? MeetingRoomList { get; set; }
}

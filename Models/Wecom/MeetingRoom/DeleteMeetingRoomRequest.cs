
namespace GaoXinLibrary.TencentSDK.Wecom.Models.MeetingRoom;

/// <summary>删除会议室请求</summary>
public sealed class DeleteMeetingRoomRequest
{
    /// <summary>会议室 ID</summary>
    [JsonPropertyName("meetingroom_id")]
    public int MeetingRoomId { get; set; }
}

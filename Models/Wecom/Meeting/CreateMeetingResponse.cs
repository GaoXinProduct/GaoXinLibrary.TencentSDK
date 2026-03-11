using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>创建预约会议响应</summary>
public class CreateMeetingResponse : WecomBaseResponse
{
    /// <summary>会议ID</summary>
    [JsonPropertyName("meetingid")] public string? MeetingId { get; set; }

    /// <summary>会议号</summary>
    [JsonPropertyName("meeting_code")] public string? MeetingCode { get; set; }
}

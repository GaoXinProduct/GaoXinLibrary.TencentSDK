using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取会议详情响应</summary>
public class GetMeetingResponse : WecomBaseResponse
{
    /// <summary>会议信息</summary>
    [JsonPropertyName("meeting_info")] public MeetingInfo? MeetingInfo { get; set; }
}

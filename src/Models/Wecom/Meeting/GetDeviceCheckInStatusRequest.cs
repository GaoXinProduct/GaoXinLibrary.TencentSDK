using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取成员设备是否入会请求</summary>
/// <remarks>doc path: /98165</remarks>
public record GetDeviceCheckInStatusRequest
{
    /// <summary>会议ID</summary>
    [JsonPropertyName("meetingid")]
    public string MeetingId { get; init; } = string.Empty;

    /// <summary>用户userid列表（单次最多100个）</summary>
    [JsonPropertyName("userid_list")]
    public List<string> UserIdList { get; init; } = new();
}
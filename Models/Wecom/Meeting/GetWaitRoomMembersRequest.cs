using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取等候室成员记录请求</summary>
/// <remarks>doc path: /98164</remarks>
public record GetWaitRoomMembersRequest
{
    /// <summary>会议ID</summary>
    [JsonPropertyName("meetingid")]
    public string MeetingId { get; init; } = string.Empty;

    /// <summary>返回的最大记录数，最大3000，默认100</summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; init; }

    /// <summary>分页游标</summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; init; }
}
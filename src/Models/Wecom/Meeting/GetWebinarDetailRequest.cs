using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取网络研讨会详情请求</summary>
/// <remarks>doc path: /98860</remarks>
public record GetWebinarDetailRequest
{
    /// <summary>研讨会 ID。与会议号同时指定时优先使用 ID。</summary>
    [JsonPropertyName("meetingid")]
    public string? WebinarId { get; init; }

    /// <summary>查询所用会议号。未指定研讨会 ID 时必须提供。</summary>
    [JsonPropertyName("meeting_code")]
    public string? MeetingCode { get; init; }

    /// <summary>返回的直播链接</summary>
    [Obsolete("网络研讨会详情接口不支持 with_live_url。")]
    [JsonIgnore]
    public bool? WithLiveUrl { get; init; }
}

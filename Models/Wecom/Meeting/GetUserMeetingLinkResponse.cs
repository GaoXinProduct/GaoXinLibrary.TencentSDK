using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>获取用户专属参会链接响应</summary>
/// <remarks>doc path: /98819</remarks>
public class GetUserMeetingLinkResponse : WecomBaseResponse
{
    /// <summary>链接列表</summary>
    [JsonPropertyName("links")]
    public List<UserMeetingLinkInfo>? Links { get; set; }
}

/// <summary>用户会议链接信息</summary>
public class UserMeetingLinkInfo
{
    /// <summary>会议ID</summary>
    [JsonPropertyName("meetingid")]
    public string? MeetingId { get; set; }

    /// <summary>会议号</summary>
    [JsonPropertyName("meeting_code")]
    public string? MeetingCode { get; set; }

    /// <summary>链接类型：1-入会链接，2-成为主持人链接</summary>
    [JsonPropertyName("link_type")]
    public int LinkType { get; set; }

    /// <summary>链接URL</summary>
    [JsonPropertyName("link_url")]
    public string? LinkUrl { get; set; }

    /// <summary>链接过期时间（Unix 时间戳，秒）</summary>
    [JsonPropertyName("expire_time")]
    public long ExpireTime { get; set; }
}
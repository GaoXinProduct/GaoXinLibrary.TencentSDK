using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>创建用户专属参会链接响应</summary>
/// <remarks>doc path: /98818</remarks>
public class CreateUserMeetingLinkResponse : WecomBaseResponse
{
    /// <summary>链接URL</summary>
    [JsonPropertyName("link_url")]
    public string? LinkUrl { get; set; }

    /// <summary>链接过期时间（Unix 时间戳，秒）</summary>
    [JsonPropertyName("expire_time")]
    public long ExpireTime { get; set; }
}
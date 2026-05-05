using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>创建网络研讨会响应</summary>
/// <remarks>doc path: /98842</remarks>
public class CreateWebinarResponse : WecomBaseResponse
{
    /// <summary>研讨会ID</summary>
    [JsonPropertyName("webinar_id")]
    public string? WebinarId { get; set; }

    /// <summary>研讨会号</summary>
    [JsonPropertyName("webinar_code")]
    public string? WebinarCode { get; set; }

    /// <summary>入会链接</summary>
    [JsonPropertyName("join_url")]
    public string? JoinUrl { get; set; }

    /// <summary>直播链接</summary>
    [JsonPropertyName("live_url")]
    public string? LiveUrl { get; set; }
}
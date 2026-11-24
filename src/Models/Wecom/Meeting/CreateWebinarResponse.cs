using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>创建网络研讨会响应</summary>
/// <remarks>doc path: /98842</remarks>
public class CreateWebinarResponse : WecomBaseResponse
{
    /// <summary>研讨会ID</summary>
    [JsonPropertyName("meetingid")]
    public string? WebinarId { get; set; }

    /// <summary>研讨会号</summary>
    [JsonPropertyName("meeting_code")]
    public string? WebinarCode { get; set; }

    /// <summary>观众入会链接。</summary>
    [JsonPropertyName("audience_join_link")]
    public string? JoinUrl { get; set; }

    /// <summary>直播链接</summary>
    [JsonPropertyName("live_url")]
    public string? LiveUrl { get; set; }

    [JsonPropertyName("subject")] public string? Subject { get; set; }
    [JsonPropertyName("start_time")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public long? WebinarStart { get; set; }
    [JsonPropertyName("end_time")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public long? WebinarEnd { get; set; }
    [JsonPropertyName("admission_type")] public int AdmissionType { get; set; }
    [JsonPropertyName("password")] public string? Password { get; set; }
    [JsonPropertyName("guest_join_link")] public string? GuestJoinUrl { get; set; }
    [JsonPropertyName("manual_check_link")] public string? ManualCheckUrl { get; set; }
    [JsonPropertyName("manual_check_password")] public string? ManualCheckPassword { get; set; }
}

using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>修改网络研讨会请求</summary>
/// <remarks>doc path: /98843</remarks>
public record ModifyWebinarRequest : WebinarOptions
{
    /// <summary>研讨会ID</summary>
    [JsonPropertyName("meetingid")]
    public string WebinarId { get; init; } = string.Empty;

    /// <summary>用户userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; init; } = string.Empty;

    /// <summary>研讨会标题</summary>
    [JsonPropertyName("subject")]
    public string? Subject { get; init; }

    /// <summary>研讨会开始时间（Unix 时间戳，秒）</summary>
    [JsonPropertyName("start_time")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
    public long? WebinarStart { get; init; }

    /// <summary>研讨会结束时间（Unix 时间戳，秒）</summary>
    [JsonPropertyName("end_time")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
    public long? WebinarEnd { get; init; }
}

using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;

/// <summary>创建网络研讨会请求</summary>
/// <remarks>doc path: /98842</remarks>
public record CreateWebinarRequest : WebinarOptions
{
    /// <summary>研讨会标题</summary>
    [JsonPropertyName("subject")]
    public string Subject { get; init; } = string.Empty;

    /// <summary>研讨会开始时间（Unix 时间戳，秒）</summary>
    [JsonPropertyName("start_time")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
    public long WebinarStart { get; init; }

    /// <summary>研讨会结束时间（Unix 时间戳，秒）</summary>
    [JsonPropertyName("end_time")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
    public long WebinarEnd { get; init; }

    /// <summary>用户userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; init; } = string.Empty;

    /// <summary>创建时是否同步到企业微信。</summary>
    [JsonPropertyName("sync_to_wework")]
    public bool? SyncToWeWork { get; init; }

    /// <summary>嘉宾userid列表</summary>
    [Obsolete("创建网络研讨会接口不支持 guest_userids。")]
    [JsonIgnore]
    public List<string>? GuestUserIds { get; init; }
}

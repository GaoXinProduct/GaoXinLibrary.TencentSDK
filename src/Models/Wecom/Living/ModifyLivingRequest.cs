using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Living;

/// <summary>修改预约直播请求</summary>
public record ModifyLivingRequest
{
    /// <summary>直播 ID</summary>
    [JsonPropertyName("livingid")]
    public string LivingId { get; init; } = string.Empty;

    /// <summary>直播标题（可选）</summary>
    [JsonPropertyName("theme")]
    public string? Theme { get; init; }

    /// <summary>直播开始时间（Unix 时间戳，秒）（可选）</summary>
    [JsonPropertyName("living_start")]
    public long? LivingStart { get; init; }

    /// <summary>直播持续时间（秒）（可选）</summary>
    [JsonPropertyName("living_duration")]
    public long? LivingDuration { get; init; }

    /// <summary>直播描述（可选）</summary>
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    /// <summary>直播类型：0 通用直播，1 小班课，2 大班课，3 企业培训，4 活动直播（可选）</summary>
    [JsonPropertyName("type")]
    public int? Type { get; init; }
}
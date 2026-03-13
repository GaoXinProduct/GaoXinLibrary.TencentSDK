using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Living;

/// <summary>修改预约直播请求</summary>
public class UpdateLivingRequest
{
    /// <summary>直播 ID</summary>
    [JsonPropertyName("livingid")]
    public string LivingId { get; set; } = string.Empty;

    /// <summary>直播标题（可选）</summary>
    [JsonPropertyName("theme")]
    public string? Theme { get; set; }

    /// <summary>直播开始时间（Unix 时间戳，秒）（可选）</summary>
    [JsonPropertyName("living_start")]
    public long? LivingStart { get; set; }

    /// <summary>直播持续时间（秒）（可选）</summary>
    [JsonPropertyName("living_duration")]
    public long? LivingDuration { get; set; }

    /// <summary>直播描述（可选）</summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }
}

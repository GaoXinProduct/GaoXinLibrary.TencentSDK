using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Living;

/// <summary>创建预约直播请求</summary>
public class CreateLivingRequest
{
    /// <summary>主播的 userid</summary>
    [JsonPropertyName("anchor_userid")]
    public string AnchorUserId { get; set; } = string.Empty;

    /// <summary>直播标题</summary>
    [JsonPropertyName("theme")]
    public string Theme { get; set; } = string.Empty;

    /// <summary>直播开始时间（Unix 时间戳，秒）</summary>
    [JsonPropertyName("living_start")]
    public long LivingStart { get; set; }

    /// <summary>直播持续时间（秒）</summary>
    [JsonPropertyName("living_duration")]
    public long LivingDuration { get; set; }

    /// <summary>直播类型：0 通用直播，1 小班课，2 大班课，3 企业培训，4 活动直播</summary>
    [JsonPropertyName("type")]
    public int Type { get; set; }

    /// <summary>直播描述（可选）</summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }
}

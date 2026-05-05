using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Living;

/// <summary>获取直播观看明细请求</summary>
public record GetLivingWatchDetailRequest
{
    /// <summary>直播 ID</summary>
    [JsonPropertyName("livingid")]
    public string LivingId { get; init; } = string.Empty;

    /// <summary>单次拉取查询的数据条数（默认 100，最大 1000）</summary>
    [JsonPropertyName("limit")]
    public int Limit { get; init; } = 100;

    /// <summary>翻页查询的游标（用于继续查询下一次）</summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; init; }
}
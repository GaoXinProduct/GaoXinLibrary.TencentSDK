using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 获取小程序交易体验分违规记录响应
/// </summary>
public sealed class GetPenaltyListResponse : WechatBaseResponse
{
    /// <summary>违规记录列表</summary>
    [JsonPropertyName("penalty_list")] public List<PenaltyItem>? PenaltyList { get; init; }
    /// <summary>总数</summary>
    [JsonPropertyName("total")] public int Total { get; init; }
}

public sealed class PenaltyItem
{
    [JsonPropertyName("penalty_id")] public string? PenaltyId { get; init; }
    [JsonPropertyName("order_id")] public string? OrderId { get; init; }
    [JsonPropertyName("penalty_type")] public int PenaltyType { get; init; }
    [JsonPropertyName("penalty_time")] public long PenaltyTime { get; init; }
    [JsonPropertyName("status")] public int Status { get; init; }
}

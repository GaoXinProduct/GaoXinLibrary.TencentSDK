using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 获取电子面单余额响应
/// </summary>
public sealed class GetQuotaResponse : WechatBaseResponse
{
    /// <summary>快递公司ID</summary>
    [JsonPropertyName("delivery_id")] public string? DeliveryId { get; init; }
    /// <summary>电子面单余额数量</summary>
    [JsonPropertyName("quota_num")] public int QuotaNum { get; init; }
    /// <summary>本月已使用数量</summary>
    [JsonPropertyName("used_num")] public int UsedNum { get; init; }
    /// <summary>本月额度</summary>
    [JsonPropertyName("month_quota")] public int MonthQuota { get; init; }
}
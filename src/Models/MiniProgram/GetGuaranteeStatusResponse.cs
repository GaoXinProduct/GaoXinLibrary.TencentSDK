using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 获取交易保障标状态响应
/// </summary>
public sealed class GetGuaranteeStatusResponse : WechatBaseResponse
{
    /// <summary>交易保障标状态（0无标 1有标）</summary>
    [JsonPropertyName("status")] public int Status { get; init; }
    /// <summary>评分</summary>
    [JsonPropertyName("score")] public double Score { get; init; }
}

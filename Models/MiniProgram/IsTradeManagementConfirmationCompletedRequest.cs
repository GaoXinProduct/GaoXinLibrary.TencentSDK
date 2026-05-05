using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 查询交易结算管理确认状态请求
/// </summary>
public sealed class IsTradeManagementConfirmationCompletedRequest
{
    /// <summary>订单ID</summary>
    [JsonPropertyName("order_id")] public string? OrderId { get; set; }
}
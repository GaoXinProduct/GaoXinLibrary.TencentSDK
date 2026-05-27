using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 查询交易结算管理确认状态响应
/// </summary>
public sealed class IsTradeManagementConfirmationCompletedResponse : WechatBaseResponse
{
    /// <summary>是否已完成确认</summary>
    [JsonPropertyName("is_confirmation_completed")] public bool IsConfirmationCompleted { get; init; }
}
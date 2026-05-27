using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 预取消配送单响应
/// </summary>
public sealed class PreCancelOrderResponse : WechatBaseResponse
{
    /// <summary>取消状态（0不可取消 1可取消）</summary>
    [JsonPropertyName("cancelable")] public int Cancelable { get; init; }
    /// <summary>取消违约金（分）</summary>
    [JsonPropertyName("cancel_fee")] public int CancelFee { get; init; }
}
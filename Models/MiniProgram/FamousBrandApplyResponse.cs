using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 品牌申请响应
/// </summary>
public sealed class FamousBrandApplyResponse : WechatBaseResponse
{
    /// <summary>申请单ID</summary>
    [JsonPropertyName("apply_id")] public string? ApplyId { get; init; }
}
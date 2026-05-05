using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 品牌申请状态查询响应
/// </summary>
public sealed class GetFamousBrandApplyStatusResponse : WechatBaseResponse
{
    /// <summary>申请状态（0审核中 1通过 2拒绝）</summary>
    [JsonPropertyName("status")] public int Status { get; init; }
    /// <summary>审核备注</summary>
    [JsonPropertyName("audit_remark")] public string? AuditRemark { get; init; }
}
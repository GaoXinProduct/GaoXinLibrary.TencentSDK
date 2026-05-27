using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 品牌申请状态查询请求
/// </summary>
public sealed class GetFamousBrandApplyStatusRequest
{
    /// <summary>申请单ID</summary>
    [JsonPropertyName("apply_id")] public required string ApplyId { get; set; }
}
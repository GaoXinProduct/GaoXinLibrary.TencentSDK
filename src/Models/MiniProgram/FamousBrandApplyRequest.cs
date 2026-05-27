using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 品牌申请请求（POST /wxa/sec/order/famous_brand/apply）
/// </summary>
public sealed class FamousBrandApplyRequest
{
    /// <summary>品牌名称</summary>
    [JsonPropertyName("brand_name")] public required string BrandName { get; set; }
    /// <summary>品牌证照URL列表</summary>
    [JsonPropertyName("license_list")] public List<string>? LicenseList { get; set; }
    /// <summary>申请说明</summary>
    [JsonPropertyName("remark")] public string? Remark { get; set; }
}
using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 查询license资源包列表请求（POST /device/license/package/getlist）
/// </summary>
public sealed class GetLicensePkgListRequest
{
    /// <summary>偏移量</summary>
    [JsonPropertyName("offset")] public int Offset { get; set; } = 0;
    /// <summary>每页数量</summary>
    [JsonPropertyName("limit")] public int Limit { get; set; } = 10;
}
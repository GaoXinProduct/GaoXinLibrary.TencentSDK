using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 配置面单打印员请求（POST /cgi-bin/express/business/printer/update）
/// </summary>
public sealed class UpdatePrinterRequest
{
    /// <summary>打印机ID</summary>
    [JsonPropertyName("printer_id")] public required string PrinterId { get; set; }
    /// <summary>打印员OpenID</summary>
    [JsonPropertyName("openid")] public required string OpenId { get; set; }
    /// <summary>备注</summary>
    [JsonPropertyName("remark")] public string? Remark { get; set; }
}
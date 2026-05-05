using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 获取打印员请求（POST /cgi-bin/express/business/printer/get）
/// </summary>
public sealed class GetPrinterRequest
{
    /// <summary>打印员OpenID</summary>
    [JsonPropertyName("openid")] public required string OpenId { get; set; }
}
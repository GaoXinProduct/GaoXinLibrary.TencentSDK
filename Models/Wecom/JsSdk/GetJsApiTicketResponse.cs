using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.JsSdk;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>获取 jsapi_ticket 响应</summary>
public class GetJsApiTicketResponse : WecomBaseResponse
{
    /// <summary>生成签名所需的 jsapi_ticket</summary>
    [JsonPropertyName("ticket")] public string Ticket { get; set; } = string.Empty;

    /// <summary>凭证的有效时间（秒）</summary>
    [JsonPropertyName("expires_in")] public int ExpiresIn { get; set; }
}


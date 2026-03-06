using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 获取 JS-SDK ticket 响应（GET /cgi-bin/ticket/getticket）
/// </summary>
public class GetJsApiTicketResponse : WechatBaseResponse
{
    /// <summary>js_ticket</summary>
    [JsonPropertyName("ticket")] public string? Ticket { get; set; }

    /// <summary>有效时间（秒）</summary>
    [JsonPropertyName("expires_in")] public int ExpiresIn { get; set; }
}


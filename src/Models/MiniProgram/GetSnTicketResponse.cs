using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 获取设备票据响应
/// </summary>
public sealed class GetSnTicketResponse : WechatBaseResponse
{
    /// <summary>设备票据</summary>
    [JsonPropertyName("ticket")] public string? Ticket { get; init; }
    /// <summary>有效期（秒）</summary>
    [JsonPropertyName("expires_in")] public int ExpiresIn { get; init; }
}
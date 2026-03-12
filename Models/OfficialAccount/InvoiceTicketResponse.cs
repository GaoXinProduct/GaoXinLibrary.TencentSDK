using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 获取发票临时票据响应
/// </summary>
public class InvoiceTicketResponse : WechatBaseResponse
{
    /// <summary>临时票据</summary>
    [JsonPropertyName("ticket")] public string? Ticket { get; set; }

    /// <summary>有效期（秒）</summary>
    [JsonPropertyName("expires_in")] public int ExpiresIn { get; set; }
}

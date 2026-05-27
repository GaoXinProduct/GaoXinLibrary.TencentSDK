using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 获取开票平台识别码响应
/// </summary>
public sealed class InvoicePlatformSetUrlResponse : WechatBaseResponse
{
    /// <summary>开票平台专用授权链接</summary>
    [JsonPropertyName("invoice_url")] public string? InvoiceUrl { get; set; }
}

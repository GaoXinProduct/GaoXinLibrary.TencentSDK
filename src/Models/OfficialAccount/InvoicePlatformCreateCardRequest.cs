using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 创建发票卡券模板请求
/// </summary>
public sealed class InvoicePlatformCreateCardRequest
{
    [JsonPropertyName("invoice_info")] public required InvoicePlatformCardInfo InvoiceInfo { get; set; }
}

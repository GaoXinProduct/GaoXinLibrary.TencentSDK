using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 设置商户联系方式请求
/// </summary>
public class InvoiceSetContactRequest
{
    /// <summary>联系方式信息</summary>
    [JsonPropertyName("contact")] public required InvoiceContactInfo Contact { get; set; }
}

using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 关联商户号与开票平台请求
/// </summary>
public class InvoiceSetPayMchRequest
{
    /// <summary>微信商户号与开票平台关系信息</summary>
    [JsonPropertyName("paymch_info")] public required InvoicePayMchInfo PayMchInfo { get; set; }
}

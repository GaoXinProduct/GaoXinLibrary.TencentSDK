using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 查询与设置授权页与商户信息响应
/// </summary>
public class InvoiceSetBizAttrResponse : WechatBaseResponse
{
    /// <summary>授权页字段（set_auth_field/get_auth_field 返回）</summary>
    [JsonPropertyName("auth_field")] public InvoiceAuthField? AuthField { get; set; }

    /// <summary>微信商户号与开票平台关系信息（get_pay_mch 返回）</summary>
    [JsonPropertyName("paymch_info")] public InvoicePayMchInfo? PayMchInfo { get; set; }

    /// <summary>联系方式信息（get_contact 返回）</summary>
    [JsonPropertyName("contact")] public InvoiceContactInfo? Contact { get; set; }
}

using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 微信商户号与开票平台关系信息
/// </summary>
public class InvoicePayMchInfo
{
    /// <summary>微信支付商户号</summary>
    [JsonPropertyName("mchid")] public required string MchId { get; set; }

    /// <summary>开票平台 id（由开票平台提供）</summary>
    [JsonPropertyName("s_pappid")] public required string SPAppId { get; set; }
}

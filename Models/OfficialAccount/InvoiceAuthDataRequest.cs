using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 查询发票授权信息请求
/// </summary>
public class InvoiceAuthDataRequest
{
    /// <summary>订单 order_id</summary>
    [JsonPropertyName("order_id")] public required string OrderId { get; set; }

    /// <summary>开票平台/财政局标识</summary>
    [JsonPropertyName("s_pappid")] public required string SPAppId { get; set; }
}

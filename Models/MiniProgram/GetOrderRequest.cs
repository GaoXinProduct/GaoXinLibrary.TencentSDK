using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>
/// 查询订单发货状态请求（POST /wxa/sec/order/get_order）
/// </summary>
public class GetOrderRequest
{
    /// <summary>
    /// 原支付交易对应的微信订单号
    /// </summary>
    [JsonPropertyName("transaction_id")] public string? TransactionId { get; set; }

    /// <summary>
    /// 支付下单商户的商户号
    /// </summary>
    [JsonPropertyName("merchant_id")] public string? MerchantId { get; set; }

    /// <summary>
    /// 二级商户号（微信支付分配）
    /// </summary>
    [JsonPropertyName("sub_merchant_id")] public string? SubMerchantId { get; set; }

    /// <summary>
    /// 商户系统内部订单号
    /// </summary>
    [JsonPropertyName("merchant_trade_no")] public string? MerchantTradeNo { get; set; }
}


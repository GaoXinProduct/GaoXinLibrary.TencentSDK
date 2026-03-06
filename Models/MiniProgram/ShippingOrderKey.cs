using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>订单标识</summary>
public class ShippingOrderKey
{
    /// <summary>
    /// 订单单号类型（1 微信支付单号；2 商户单号）
    /// </summary>
    [JsonPropertyName("order_number_type")] public int OrderNumberType { get; set; }

    /// <summary>
    /// 原支付交易对应的微信订单号（order_number_type = 1 时必填）
    /// </summary>
    [JsonPropertyName("transaction_id")] public string? TransactionId { get; set; }

    /// <summary>
    /// 支付下单商户的商户号（order_number_type = 1 时必填）
    /// </summary>
    [JsonPropertyName("mchid")] public string? MchId { get; set; }

    /// <summary>
    /// 商户系统内部订单号（order_number_type = 2 时必填）
    /// </summary>
    [JsonPropertyName("out_trade_no")] public string? OutTradeNo { get; set; }
}


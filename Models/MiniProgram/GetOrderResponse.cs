using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>
/// 查询订单发货状态响应
/// </summary>
public class GetOrderResponse : WechatBaseResponse
{
    /// <summary>微信订单号</summary>
    [JsonPropertyName("transaction_id")] public string? TransactionId { get; set; }

    /// <summary>商户号</summary>
    [JsonPropertyName("merchant_id")] public string? MerchantId { get; set; }

    /// <summary>子商户号</summary>
    [JsonPropertyName("sub_merchant_id")] public string? SubMerchantId { get; set; }

    /// <summary>商户订单号</summary>
    [JsonPropertyName("merchant_trade_no")] public string? MerchantTradeNo { get; set; }

    /// <summary>发货描述</summary>
    [JsonPropertyName("description")] public string? Description { get; set; }

    /// <summary>支付金额（分）</summary>
    [JsonPropertyName("paid_amount")] public int PaidAmount { get; set; }

    /// <summary>订单状态（可能为 shipping / finished 等）</summary>
    [JsonPropertyName("order_state")] public int OrderState { get; set; }

    /// <summary>是否已全部发货</summary>
    [JsonPropertyName("is_all_delivered")] public bool IsAllDelivered { get; set; }

    /// <summary>物流信息列表</summary>
    [JsonPropertyName("shipping_list")] public List<ShippingItem>? ShippingList { get; set; }

    /// <summary>确认收货方式（1 自动确认收货；2 手动确认收货）</summary>
    [JsonPropertyName("confirm_receive_method")] public int ConfirmReceiveMethod { get; set; }
}


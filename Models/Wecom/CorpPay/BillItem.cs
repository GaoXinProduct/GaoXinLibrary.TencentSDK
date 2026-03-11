using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CorpPay;

/// <summary>收款记录</summary>
public class BillItem
{
    /// <summary>交易单号</summary>
    [JsonPropertyName("transaction_id")] public string? TransactionId { get; set; }

    /// <summary>商户单号</summary>
    [JsonPropertyName("trade_no")] public string? TradeNo { get; set; }

    /// <summary>交易状态</summary>
    [JsonPropertyName("trade_state")] public int TradeState { get; set; }

    /// <summary>金额（分）</summary>
    [JsonPropertyName("total_fee")] public int TotalFee { get; set; }

    /// <summary>付款时间</summary>
    [JsonPropertyName("pay_time")] public long PayTime { get; set; }

    /// <summary>收款人userid</summary>
    [JsonPropertyName("payer_userid")] public string? PayerUserId { get; set; }

    /// <summary>收款项目名称</summary>
    [JsonPropertyName("commodity_name")] public string? CommodityName { get; set; }
}

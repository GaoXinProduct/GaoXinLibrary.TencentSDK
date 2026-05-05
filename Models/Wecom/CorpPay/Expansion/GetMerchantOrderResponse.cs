using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CorpPay.Expansion;

public class GetMerchantOrderResponse : WecomBaseResponse
{
    [JsonPropertyName("merchant_order")]
    public MerchantOrder? MerchantOrder { get; set; }
}

public class MerchantOrder
{
    [JsonPropertyName("order_id")]
    public string? OrderId { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("amount")]
    public int Amount { get; set; }
}
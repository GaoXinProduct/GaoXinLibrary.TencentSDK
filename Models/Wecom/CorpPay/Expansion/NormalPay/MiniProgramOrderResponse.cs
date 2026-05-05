using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CorpPay.Expansion.NormalPay;

public class MiniProgramOrderResponse : WecomBaseResponse
{
    [JsonPropertyName("order_id")]
    public string? OrderId { get; set; }

    [JsonPropertyName("prepay_id")]
    public string? PrepayId { get; set; }
}
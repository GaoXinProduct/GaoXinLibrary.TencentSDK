using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CorpPay.Expansion.NormalPay;

public class GetPaySignatureResponse : WecomBaseResponse
{
    [JsonPropertyName("pay_info")]
    public PayInfo? PayInfo { get; set; }
}

public class PayInfo
{
    [JsonPropertyName("signature")]
    public string? Signature { get; set; }

    [JsonPropertyName("nonce_str")]
    public string? NonceStr { get; set; }
}
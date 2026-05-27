using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CorpPay.Expansion.ExternalAccount;

public class QueryCreateAccountStatusRequest
{
    [JsonPropertyName("apply_id")]
    public string? ApplyId { get; set; }
}
using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CorpPay.Expansion.ExternalAccount;

public class QueryCreateAccountStatusResponse : WecomBaseResponse
{
    [JsonPropertyName("status")]
    public int Status { get; set; }

    [JsonPropertyName("reject_reason")]
    public string? RejectReason { get; set; }
}
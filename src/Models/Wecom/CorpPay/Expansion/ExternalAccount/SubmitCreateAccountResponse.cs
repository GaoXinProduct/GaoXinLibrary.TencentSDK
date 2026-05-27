using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CorpPay.Expansion.ExternalAccount;

public class SubmitCreateAccountResponse : WecomBaseResponse
{
    [JsonPropertyName("apply_id")]
    public string? ApplyId { get; set; }
}
using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CorpPay.Expansion.ExternalAccount;

public class SubmitCreateAccountRequest
{
    [JsonPropertyName("brand_id")]
    public string? BrandId { get; set; }

    [JsonPropertyName("account_name")]
    public string? AccountName { get; set; }

    [JsonPropertyName("account_type")]
    public int AccountType { get; set; }

    [JsonPropertyName("sub_account_type")]
    public int? SubAccountType { get; set; }
}
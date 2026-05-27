using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CorpPay.Expansion.ExternalAccount;

public class SubmitAccountImageRequest
{
    [JsonPropertyName("apply_id")]
    public string? ApplyId { get; set; }

    [JsonPropertyName("image_url")]
    public string? ImageUrl { get; set; }

    [JsonPropertyName("image_type")]
    public int ImageType { get; set; }
}
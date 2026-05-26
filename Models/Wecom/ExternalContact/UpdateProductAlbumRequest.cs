
namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

public sealed class UpdateProductAlbumRequest
{
    [JsonPropertyName("product_id")]
    public string ProductId { get; set; } = string.Empty;

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("price")]
    public int? Price { get; set; }

    [JsonPropertyName("product_sn")]
    public string? ProductSn { get; set; }

    [JsonPropertyName("attachments")]
    public ProductAlbumAttachment[]? Attachments { get; set; }
}

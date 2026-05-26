using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

public sealed class AddProductAlbumResponse : WecomBaseResponse
{
    [JsonPropertyName("product_id")]
    public string? ProductId { get; set; }
}

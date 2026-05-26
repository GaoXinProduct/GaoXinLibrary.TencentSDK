using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

public sealed class GetProductAlbumResponse : WecomBaseResponse
{
    [JsonPropertyName("product")]
    public ProductAlbumInfo? Product { get; set; }
}

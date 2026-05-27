using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

public sealed class GetProductAlbumListResponse : WecomBaseResponse
{
    [JsonPropertyName("next_cursor")]
    public string? NextCursor { get; set; }

    [JsonPropertyName("product_list")]
    public ProductAlbumInfo[]? ProductList { get; set; }
}

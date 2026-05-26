
namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

public sealed class GetProductAlbumRequest
{
    [JsonPropertyName("product_id")]
    public string ProductId { get; set; } = string.Empty;
}

public sealed class ProductAlbumInfo
{
    [JsonPropertyName("product_id")]
    public string? ProductId { get; set; }

    [JsonPropertyName("product_sn")]
    public string? ProductSn { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("price")]
    public int Price { get; set; }

    [JsonPropertyName("create_time")]
    public long CreateTime { get; set; }

    [JsonPropertyName("attachments")]
    public ProductAlbumAttachment[]? Attachments { get; set; }
}

/// <summary>商品图册附件</summary>
public sealed class ProductAlbumAttachment
{
    /// <summary>附件类型，固定为 image</summary>
    [JsonPropertyName("type")]
    public string Type { get; set; } = "image";

    /// <summary>图片信息</summary>
    [JsonPropertyName("image")]
    public ProductAlbumImage Image { get; set; } = new();
}

/// <summary>商品图册图片</summary>
public sealed class ProductAlbumImage
{
    /// <summary>图片 media_id</summary>
    [JsonPropertyName("media_id")]
    public string MediaId { get; set; } = string.Empty;
}

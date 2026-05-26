
namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>添加商品图册请求</summary>
public sealed class AddProductAlbumRequest
{
    /// <summary>商品描述</summary>
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    /// <summary>价格（分）</summary>
    [JsonPropertyName("price")]
    public int Price { get; set; }

    /// <summary>商品编码</summary>
    [JsonPropertyName("product_sn")]
    public string? ProductSn { get; set; }

    /// <summary>附件（图片）列表</summary>
    [JsonPropertyName("attachments")]
    public ProductAlbumAttachment[]? Attachments { get; set; }
}

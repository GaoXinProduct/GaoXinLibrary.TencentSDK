using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>物流信息项</summary>
public class ShippingItem
{
    /// <summary>物流单号</summary>
    [JsonPropertyName("tracking_no")] public string? TrackingNo { get; set; }

    /// <summary>
    /// 物流公司编码（参见微信物流公司编码表，如 SF 表示顺丰速运）
    /// </summary>
    [JsonPropertyName("express_company")] public string? ExpressCompany { get; set; }

    /// <summary>包裹中的商品信息</summary>
    [JsonPropertyName("item_desc")] public string? ItemDesc { get; set; }

    /// <summary>联系方式</summary>
    [JsonPropertyName("contact")] public ShippingContact? Contact { get; set; }
}


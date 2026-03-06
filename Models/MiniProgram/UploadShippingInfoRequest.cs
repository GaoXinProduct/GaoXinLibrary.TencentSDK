using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 发货信息录入请求（POST /wxa/sec/order/upload_shipping_info）
/// <para>
/// 商户在小程序内调起微信支付后，需要在发货后通过此接口上传发货信息。
/// </para>
/// </summary>
public class UploadShippingInfoRequest
{
    /// <summary>订单（需要上传物流信息的订单）</summary>
    [JsonPropertyName("order_key")] public required ShippingOrderKey OrderKey { get; set; }

    /// <summary>物流模式（1 实体物流配送；2 同城配送；3 虚拟商品；4 用户自提）</summary>
    [JsonPropertyName("delivery_mode")] public int DeliveryMode { get; set; }

    /// <summary>物流信息列表（发货方式为实体物流/同城配送时必填）</summary>
    [JsonPropertyName("shipping_list")] public List<ShippingItem>? ShippingList { get; set; }

    /// <summary>上传时间（Unix 时间戳，单位秒）</summary>
    [JsonPropertyName("upload_time")] public string? UploadTime { get; set; }

    /// <summary>
    /// 用于标识完成发货的订单
    /// <para>
    /// 需要上传物流信息的发货完成订单，其值为 true；
    /// 如果需要分拆发货，先上传分拆的物流信息，最后一次上传时设为 true
    /// </para>
    /// </summary>
    [JsonPropertyName("is_all_delivered")] public bool IsAllDelivered { get; set; }
}


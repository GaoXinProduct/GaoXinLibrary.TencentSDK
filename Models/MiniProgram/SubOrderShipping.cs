using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>子订单发货信息</summary>
public class SubOrderShipping
{
    /// <summary>子订单标识</summary>
    [JsonPropertyName("order_key")] public required ShippingOrderKey OrderKey { get; set; }

    /// <summary>物流模式（1 实体物流配送；2 同城配送；3 虚拟商品；4 用户自提）</summary>
    [JsonPropertyName("delivery_mode")] public int DeliveryMode { get; set; }

    /// <summary>物流信息列表</summary>
    [JsonPropertyName("shipping_list")] public List<ShippingItem>? ShippingList { get; set; }

    /// <summary>是否已全部发货</summary>
    [JsonPropertyName("is_all_delivered")] public bool IsAllDelivered { get; set; }
}


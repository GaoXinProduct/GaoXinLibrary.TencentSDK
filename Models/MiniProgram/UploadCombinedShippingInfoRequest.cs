using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>
/// 发货信息合单录入请求（POST /wxa/sec/order/upload_combined_shipping_info）
/// </summary>
public class UploadCombinedShippingInfoRequest
{
    /// <summary>合单订单（需要上传物流信息的合单订单）</summary>
    [JsonPropertyName("order_key")] public required ShippingOrderKey OrderKey { get; set; }

    /// <summary>子订单发货列表</summary>
    [JsonPropertyName("sub_orders")] public required List<SubOrderShipping> SubOrders { get; set; }

    /// <summary>上传时间（Unix 时间戳，单位秒）</summary>
    [JsonPropertyName("upload_time")] public string? UploadTime { get; set; }
}


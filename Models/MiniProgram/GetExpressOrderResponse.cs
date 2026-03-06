using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>查询运单响应</summary>
public class GetExpressOrderResponse : WechatBaseResponse
{
    /// <summary>订单 ID</summary>
    [JsonPropertyName("order_id")] public string? OrderId { get; set; }
    /// <summary>订单状态</summary>
    [JsonPropertyName("order_status")] public int OrderStatus { get; set; }
    /// <summary>快递公司 ID</summary>
    [JsonPropertyName("delivery_id")] public string? DeliveryId { get; set; }
    /// <summary>运单 ID</summary>
    [JsonPropertyName("waybill_id")] public string? WaybillId { get; set; }
}


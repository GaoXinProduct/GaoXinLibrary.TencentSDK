using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>
/// 查询运单请求（POST /cgi-bin/express/business/order/get）
/// </summary>
public class GetExpressOrderRequest
{
    /// <summary>订单 ID</summary>
    [JsonPropertyName("order_id")] public required string OrderId { get; set; }
    /// <summary>用户 OpenId</summary>
    [JsonPropertyName("openid")] public string? OpenId { get; set; }
    /// <summary>快递公司 ID</summary>
    [JsonPropertyName("delivery_id")] public string? DeliveryId { get; set; }
    /// <summary>运单 ID</summary>
    [JsonPropertyName("waybill_id")] public string? WaybillId { get; set; }
}


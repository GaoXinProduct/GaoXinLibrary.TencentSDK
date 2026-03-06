using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>
/// 获取运单轨迹请求（POST /cgi-bin/express/business/path/get）
/// </summary>
public class GetExpressPathRequest
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


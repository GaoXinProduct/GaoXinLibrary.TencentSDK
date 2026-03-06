using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>获取运单轨迹响应</summary>
public class GetExpressPathResponse : WechatBaseResponse
{
    /// <summary>用户 OpenId</summary>
    [JsonPropertyName("openid")] public string? OpenId { get; set; }
    /// <summary>快递公司 ID</summary>
    [JsonPropertyName("delivery_id")] public string? DeliveryId { get; set; }
    /// <summary>运单 ID</summary>
    [JsonPropertyName("waybill_id")] public string? WaybillId { get; set; }
    /// <summary>轨迹节点列表</summary>
    [JsonPropertyName("path_item_list")] public List<ExpressPathItem>? PathItemList { get; set; }
}


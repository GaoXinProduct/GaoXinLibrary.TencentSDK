using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 获取支持的快递公司列表响应（GET /cgi-bin/express/business/delivery/getall）
/// </summary>
public class GetAllDeliveryResponse : WechatBaseResponse
{
    /// <summary>快递公司数量</summary>
    [JsonPropertyName("count")] public int Count { get; set; }
    /// <summary>快递公司列表</summary>
    [JsonPropertyName("data")] public List<DeliveryCompany>? Data { get; set; }
}


using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 获取已支持的配送公司列表响应（POST /cgi-bin/express/delivery/open/getall）
/// </summary>
public sealed class GetAllImmeDeliveryResponse : WechatBaseResponse
{
    /// <summary>配送公司列表</summary>
    [JsonPropertyName("delivery_list")] public List<DeliveryCompany>? DeliveryList { get; init; }
}
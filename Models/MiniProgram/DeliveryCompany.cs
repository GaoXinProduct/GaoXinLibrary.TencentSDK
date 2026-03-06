using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>快递公司信息</summary>
public class DeliveryCompany
{
    /// <summary>快递公司 ID</summary>
    [JsonPropertyName("delivery_id")] public string? DeliveryId { get; set; }
    /// <summary>快递公司名称</summary>
    [JsonPropertyName("delivery_name")] public string? DeliveryName { get; set; }
}


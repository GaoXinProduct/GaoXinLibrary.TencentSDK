using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 发票商品明细项
/// </summary>
public class InvoiceCommodityItem
{
    /// <summary>项目名称</summary>
    [JsonPropertyName("name")] public string? Name { get; set; }

    /// <summary>项目数量</summary>
    [JsonPropertyName("num")] public float? Num { get; set; }

    /// <summary>项目单位</summary>
    [JsonPropertyName("unit")] public string? Unit { get; set; }

    /// <summary>项目单价（分）</summary>
    [JsonPropertyName("price")] public int? Price { get; set; }
}

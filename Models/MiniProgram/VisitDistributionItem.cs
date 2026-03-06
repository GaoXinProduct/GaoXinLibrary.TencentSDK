using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>访问分布项</summary>
public class VisitDistributionItem
{
    /// <summary>分布类型</summary>
    [JsonPropertyName("index")] public string? Index { get; set; }
    /// <summary>分布数据</summary>
    [JsonPropertyName("item_list")] public List<DistributionKeyValue>? ItemList { get; set; }
}


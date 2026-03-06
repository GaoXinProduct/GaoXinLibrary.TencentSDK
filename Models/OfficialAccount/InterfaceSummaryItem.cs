using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>接口分析数据项</summary>
public class InterfaceSummaryItem
{
    [JsonPropertyName("ref_date")] public string? RefDate { get; set; }
    [JsonPropertyName("callback_count")] public int CallbackCount { get; set; }
    [JsonPropertyName("fail_count")] public int FailCount { get; set; }
    [JsonPropertyName("total_time_cost")] public int TotalTimeCost { get; set; }
    [JsonPropertyName("max_time_cost")] public int MaxTimeCost { get; set; }
}


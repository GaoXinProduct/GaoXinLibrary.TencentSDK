using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

/// <summary>时长分片信息</summary>
public class ApplySliceInfo
{
    /// <summary>每天的分片列表</summary>
    [JsonPropertyName("day_items")] public ApplyDayItem[]? DayItems { get; set; }
}

using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Checkin;

/// <summary>打卡日报数据</summary>
public class CheckinDayDataItem
{
    /// <summary>基础信息</summary>
    [JsonPropertyName("base_info")] public CheckinDayBaseInfo? BaseInfo { get; set; }

    /// <summary>汇总信息</summary>
    [JsonPropertyName("summary_info")] public CheckinDaySummaryInfo? SummaryInfo { get; set; }
}


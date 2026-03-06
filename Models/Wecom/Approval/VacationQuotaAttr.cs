using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

/// <summary>假期额度属性</summary>
public class VacationQuotaAttr
{
    /// <summary>假期是否按工龄计算</summary>
    [JsonPropertyName("type")] public int? Type { get; set; }

    /// <summary>自动发放时间，距离每年1月1日的秒数</summary>
    [JsonPropertyName("autoreset_time")] public long? AutoResetTime { get; set; }

    /// <summary>自动发放天数</summary>
    [JsonPropertyName("autoreset_duration")] public int? AutoResetDuration { get; set; }
}


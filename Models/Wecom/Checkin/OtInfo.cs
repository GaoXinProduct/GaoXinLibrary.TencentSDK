using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Checkin;

/// <summary>加班信息</summary>
public class OtInfo
{
    /// <summary>加班类型 0-申请核算 1-打卡时间 2-审批为准</summary>
    [JsonPropertyName("type")] public int? Type { get; set; }

    /// <summary>允许工作日加班</summary>
    [JsonPropertyName("allow_ot_workingday")] public bool? AllowOtWorkingday { get; set; }

    /// <summary>允许非工作日加班</summary>
    [JsonPropertyName("allow_ot_nonworkingday")] public bool? AllowOtNonworkingday { get; set; }

    /// <summary>加班时长计算规则</summary>
    [JsonPropertyName("otcheckinfo")] public OtCheckInfo? OtCheckInfo { get; set; }

    /// <summary>更新时间</summary>
    [JsonPropertyName("uptime")] public long? UpTime { get; set; }
}


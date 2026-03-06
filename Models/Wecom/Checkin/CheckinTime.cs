using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Checkin;

/// <summary>上下班打卡时间</summary>
public class CheckinTime
{
    /// <summary>上班时间，距离当天 0 点的秒数</summary>
    [JsonPropertyName("work_sec")] public int WorkSec { get; set; }

    /// <summary>下班时间，距离当天 0 点的秒数</summary>
    [JsonPropertyName("off_work_sec")] public int OffWorkSec { get; set; }

    /// <summary>上班提醒时间，距离当天 0 点的秒数</summary>
    [JsonPropertyName("remind_work_sec")] public int RemindWorkSec { get; set; }

    /// <summary>下班提醒时间，距离当天 0 点的秒数</summary>
    [JsonPropertyName("remind_off_work_sec")] public int RemindOffWorkSec { get; set; }
}


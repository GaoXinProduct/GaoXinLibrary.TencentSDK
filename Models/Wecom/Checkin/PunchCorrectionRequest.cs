using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Checkin;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>为打卡人员补卡请求</summary>
public class PunchCorrectionRequest
{
    /// <summary>用户 userid</summary>
    [JsonPropertyName("userid")] public string UserId { get; set; } = string.Empty;

    /// <summary>打卡日期对应当天 0 点的 Unix 时间戳</summary>
    [JsonPropertyName("schedule_date_time")] public long ScheduleDateTime { get; set; }

    /// <summary>打卡时间段 id</summary>
    [JsonPropertyName("schedule_checkin_time_id")] public int ScheduleCheckinTimeId { get; set; }

    /// <summary>补卡时间（Unix 时间戳）</summary>
    [JsonPropertyName("checkin_time")] public long CheckinTime { get; set; }

    /// <summary>补卡备注</summary>
    [JsonPropertyName("remark")] public string? Remark { get; set; }
}


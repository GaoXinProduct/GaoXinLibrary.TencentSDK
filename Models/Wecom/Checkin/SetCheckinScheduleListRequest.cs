using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Checkin;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>为打卡人员排班请求</summary>
public class SetCheckinScheduleListRequest
{
    /// <summary>规则 id</summary>
    [JsonPropertyName("groupid")] public int GroupId { get; set; }

    /// <summary>排班信息（月份格式 yyyyMM，如 202301）</summary>
    [JsonPropertyName("yearmonth")] public int YearMonth { get; set; }

    /// <summary>排班项列表</summary>
    [JsonPropertyName("items")] public SetScheduleItem[] Items { get; set; } = [];
}


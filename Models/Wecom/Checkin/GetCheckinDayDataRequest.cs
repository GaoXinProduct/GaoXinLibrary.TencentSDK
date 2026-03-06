using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Checkin;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>获取打卡日报数据请求</summary>
public class GetCheckinDayDataRequest
{
    /// <summary>开始时间（Unix 时间戳）</summary>
    [JsonPropertyName("starttime")] public long StartTime { get; set; }

    /// <summary>结束时间（Unix 时间戳）</summary>
    [JsonPropertyName("endtime")] public long EndTime { get; set; }

    /// <summary>用户列表</summary>
    [JsonPropertyName("useridlist")] public string[] UserIdList { get; set; } = [];
}


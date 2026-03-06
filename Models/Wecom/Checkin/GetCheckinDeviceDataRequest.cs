using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Checkin;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>获取设备打卡数据请求</summary>
public class GetCheckinDeviceDataRequest
{
    /// <summary>需要过滤的打卡类型列表，1-上班 2-下班</summary>
    [JsonPropertyName("filter_type")] public int[]? FilterType { get; set; }

    /// <summary>开始时间（Unix 时间戳）</summary>
    [JsonPropertyName("starttime")] public long StartTime { get; set; }

    /// <summary>结束时间（Unix 时间戳）</summary>
    [JsonPropertyName("endtime")] public long EndTime { get; set; }

    /// <summary>用户列表</summary>
    [JsonPropertyName("useridlist")] public string[] UserIdList { get; set; } = [];
}


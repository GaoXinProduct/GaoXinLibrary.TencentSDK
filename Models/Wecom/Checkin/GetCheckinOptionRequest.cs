using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Checkin;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>获取员工打卡规则请求</summary>
public class GetCheckinOptionRequest
{
    /// <summary>需要获取规则的日期当天 0 点的 Unix 时间戳</summary>
    [JsonPropertyName("datetime")] public long DateTime { get; set; }

    /// <summary>需要获取打卡规则的用户列表</summary>
    [JsonPropertyName("useridlist")] public string[] UserIdList { get; set; } = [];
}


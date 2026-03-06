using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Checkin;

/// <summary>月报基础信息</summary>
public class CheckinMonthBaseInfo
{
    /// <summary>用户 userid</summary>
    [JsonPropertyName("acctid")] public string? AcctId { get; set; }

    /// <summary>打卡人员名称</summary>
    [JsonPropertyName("name")] public string? Name { get; set; }

    /// <summary>打卡规则信息</summary>
    [JsonPropertyName("rule_info")] public CheckinDayRuleInfo? RuleInfo { get; set; }
}


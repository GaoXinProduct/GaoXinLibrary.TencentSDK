using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Checkin;

/// <summary>日报基础信息</summary>
public class CheckinDayBaseInfo
{
    /// <summary>日期（当天 0 点的 Unix 时间戳）</summary>
    [JsonPropertyName("date")] public long? Date { get; set; }

    /// <summary>打卡人员信息</summary>
    [JsonPropertyName("record_type")] public int? RecordType { get; set; }

    /// <summary>打卡人员 userid</summary>
    [JsonPropertyName("name")] public string? Name { get; set; }

    /// <summary>打卡人员别名</summary>
    [JsonPropertyName("name_ex")] public string? NameEx { get; set; }

    /// <summary>部门 id 列表</summary>
    [JsonPropertyName("departs_name")] public string? DepartsName { get; set; }

    /// <summary>打卡规则 id</summary>
    [JsonPropertyName("rule_info")] public CheckinDayRuleInfo? RuleInfo { get; set; }

    /// <summary>用户 userid</summary>
    [JsonPropertyName("acctid")] public string? AcctId { get; set; }
}


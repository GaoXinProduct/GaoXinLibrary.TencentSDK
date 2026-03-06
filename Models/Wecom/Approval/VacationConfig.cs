using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

/// <summary>假期配置</summary>
public class VacationConfig
{
    /// <summary>假期 id</summary>
    [JsonPropertyName("id")] public int Id { get; set; }

    /// <summary>假期名称</summary>
    [JsonPropertyName("name")] public string? Name { get; set; }

    /// <summary>假期时长单位：0-按天请假 1-按小时请假</summary>
    [JsonPropertyName("time_attr")] public int? TimeAttr { get; set; }

    /// <summary>假期发放类型：0-不自动发放 1-自动发放</summary>
    [JsonPropertyName("duration_type")] public int? DurationType { get; set; }

    /// <summary>假期过期规则</summary>
    [JsonPropertyName("quota_attr")] public VacationQuotaAttr? QuotaAttr { get; set; }

    /// <summary>是否关联加班调休</summary>
    [JsonPropertyName("perday_duration")] public int? PerdayDuration { get; set; }
}


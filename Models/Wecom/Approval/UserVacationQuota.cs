using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

/// <summary>成员假期余额</summary>
public class UserVacationQuota
{
    /// <summary>假期 id</summary>
    [JsonPropertyName("id")] public int Id { get; set; }

    /// <summary>假期名称</summary>
    [JsonPropertyName("assignduration")] public int? AssignDuration { get; set; }

    /// <summary>已使用额度（单位：秒）</summary>
    [JsonPropertyName("usedduration")] public int? UsedDuration { get; set; }

    /// <summary>剩余额度（单位：秒）</summary>
    [JsonPropertyName("leftduration")] public int? LeftDuration { get; set; }

    /// <summary>假期名称</summary>
    [JsonPropertyName("vacationname")] public string? VacationName { get; set; }
}


using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

/// <summary>修改成员假期余额请求</summary>
public class SetOneUserQuotaRequest
{
    /// <summary>成员 userid</summary>
    [JsonPropertyName("userid")] public string UserId { get; set; } = string.Empty;

    /// <summary>假期 id</summary>
    [JsonPropertyName("vacation_id")] public int VacationId { get; set; }

    /// <summary>设置的额度（单位：秒）</summary>
    [JsonPropertyName("leftduration")] public int LeftDuration { get; set; }

    /// <summary>修改时间戳</summary>
    [JsonPropertyName("time_attr")] public int? TimeAttr { get; set; }

    /// <summary>修改备注</summary>
    [JsonPropertyName("remarks")] public string? Remarks { get; set; }
}


using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

/// <summary>审批单号查询筛选条件</summary>
public class ApprovalFilter
{
    /// <summary>筛选类型：template_id / creator / department / sp_status</summary>
    [JsonPropertyName("key")] public string Key { get; set; } = string.Empty;

    /// <summary>筛选值</summary>
    [JsonPropertyName("value")] public string Value { get; set; } = string.Empty;
}


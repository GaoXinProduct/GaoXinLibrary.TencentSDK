using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

/// <summary>审批数据扩展字段</summary>
public class ApprovalDataComm
{
    /// <summary>申请数据</summary>
    [JsonPropertyName("apply_data")] public string? ApplyData { get; set; }
}


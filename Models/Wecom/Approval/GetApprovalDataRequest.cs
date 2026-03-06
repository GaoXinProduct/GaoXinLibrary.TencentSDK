using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>获取审批数据（旧）请求</summary>
public class GetApprovalDataRequest
{
    /// <summary>获取审批记录的开始时间（Unix 时间戳）</summary>
    [JsonPropertyName("starttime")] public long StartTime { get; set; }

    /// <summary>获取审批记录的结束时间（Unix 时间戳）</summary>
    [JsonPropertyName("endtime")] public long EndTime { get; set; }

    /// <summary>下一次请求的起始位置，初次传 0</summary>
    [JsonPropertyName("next_spnum")] public long? NextSpNum { get; set; }
}


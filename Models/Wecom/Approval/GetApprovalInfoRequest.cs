using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>批量获取审批单号请求</summary>
public class GetApprovalInfoRequest
{
    /// <summary>审批单提交的时间范围-开始时间（Unix 时间戳）</summary>
    [JsonPropertyName("starttime")] public long StartTime { get; set; }

    /// <summary>审批单提交的时间范围-结束时间（Unix 时间戳）</summary>
    [JsonPropertyName("endtime")] public long EndTime { get; set; }

    /// <summary>游标（初始传 0，后续使用上次返回的 new_next_cursor）</summary>
    [JsonPropertyName("cursor")] public int Cursor { get; set; }

    /// <summary>一次请求拉取审批单数，最大100</summary>
    [JsonPropertyName("size")] public int Size { get; set; } = 100;

    /// <summary>筛选条件</summary>
    [JsonPropertyName("filters")] public ApprovalFilter[]? Filters { get; set; }
}


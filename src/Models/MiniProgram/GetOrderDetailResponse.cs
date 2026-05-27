using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 查询投诉单详情响应
/// </summary>
public sealed class GetOrderDetailResponse : WechatBaseResponse
{
    [JsonPropertyName("complaint")] public ComplaintDetail? Complaint { get; init; }
}

public sealed class ComplaintDetail
{
    [JsonPropertyName("complaint_id")] public string? ComplaintId { get; init; }
    [JsonPropertyName("order_id")] public string? OrderId { get; init; }
    [JsonPropertyName("status")] public int Status { get; init; }
    [JsonPropertyName("content")] public string? Content { get; init; }
    [JsonPropertyName("create_time")] public long CreateTime { get; init; }
}

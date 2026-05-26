using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>查询客户接替结果响应</summary>
public sealed class TransferResultResponse : WecomBaseResponse
{
    [JsonPropertyName("customer")] public TransferResultItem[]? Customer { get; set; }
    [JsonPropertyName("next_cursor")] public string? NextCursor { get; set; }
}

/// <summary>客户接替结果项</summary>
public sealed class TransferResultItem
{
    [JsonPropertyName("external_userid")] public string ExternalUserId { get; set; } = string.Empty;
    [JsonPropertyName("status")] public int Status { get; set; }
    [JsonPropertyName("takeover_time")] public long TakeoverTime { get; set; }
}

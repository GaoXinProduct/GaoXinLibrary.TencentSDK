
namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>查询离职客户接替结果请求</summary>
public sealed class ResignedTransferResultRequest
{
    [JsonPropertyName("handover_userid")] public string HandoverUserId { get; set; } = string.Empty;
    [JsonPropertyName("takeover_userid")] public string TakeoverUserId { get; set; } = string.Empty;
    [JsonPropertyName("cursor")] public string? Cursor { get; set; }
}

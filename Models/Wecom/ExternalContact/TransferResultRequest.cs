
namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>查询客户接替状态请求</summary>
public sealed class TransferResultRequest
{
    [JsonPropertyName("handover_userid")] public string HandoverUserId { get; set; } = string.Empty;
    [JsonPropertyName("takeover_userid")] public string TakeoverUserId { get; set; } = string.Empty;
    [JsonPropertyName("cursor")] public string? Cursor { get; set; }
}

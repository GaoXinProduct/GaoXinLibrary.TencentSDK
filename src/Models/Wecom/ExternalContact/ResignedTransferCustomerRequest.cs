
namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>分配离职成员的客户请求</summary>
public sealed class ResignedTransferCustomerRequest
{
    [JsonPropertyName("handover_userid")] public string HandoverUserId { get; set; } = string.Empty;
    [JsonPropertyName("takeover_userid")] public string TakeoverUserId { get; set; } = string.Empty;
    [JsonPropertyName("external_userid")] public string[] ExternalUserId { get; set; } = [];
}

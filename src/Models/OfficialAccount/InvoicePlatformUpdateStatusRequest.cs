using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 更新发票卡券状态请求
/// </summary>
public sealed class InvoicePlatformUpdateStatusRequest
{
    [JsonPropertyName("card_id")] public required string CardId { get; set; }
    [JsonPropertyName("code")] public required string Code { get; set; }
    [JsonPropertyName("reimburse_status")] public required string ReimburseStatus { get; set; }
}

using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 拒绝开票请求
/// </summary>
public class InvoiceRejectInsertRequest
{
    [JsonPropertyName("s_pappid")] public required string SPAppId { get; set; }
    [JsonPropertyName("order_id")] public required string OrderId { get; set; }
    [JsonPropertyName("reason")] public required string Reason { get; set; }
    [JsonPropertyName("url")] public string? Url { get; set; }
}

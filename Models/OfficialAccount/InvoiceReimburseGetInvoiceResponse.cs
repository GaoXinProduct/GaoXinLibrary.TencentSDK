using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 查询报销发票信息响应
/// </summary>
public class InvoiceReimburseGetInvoiceResponse : WechatBaseResponse
{
    [JsonPropertyName("card_id")] public string? CardId { get; set; }
    [JsonPropertyName("begin_time")] public long? BeginTime { get; set; }
    [JsonPropertyName("end_time")] public long? EndTime { get; set; }
    [JsonPropertyName("openid")] public string? OpenId { get; set; }
    [JsonPropertyName("type")] public string? Type { get; set; }
    [JsonPropertyName("payee")] public string? Payee { get; set; }
    [JsonPropertyName("detail")] public string? Detail { get; set; }
    [JsonPropertyName("user_info")] public InvoiceUserInfo? UserInfo { get; set; }
    [JsonPropertyName("pdf_url")] public string? PdfUrl { get; set; }
    [JsonPropertyName("trip_pdf_url")] public string? TripPdfUrl { get; set; }
    [JsonPropertyName("reimburse_status")] public string? ReimburseStatus { get; set; }
}

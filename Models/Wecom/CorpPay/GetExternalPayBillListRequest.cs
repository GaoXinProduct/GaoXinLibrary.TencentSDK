
namespace GaoXinLibrary.TencentSDK.Wecom.Models.CorpPay;

/// <summary>获取对外收款记录请求</summary>
public sealed class GetExternalPayBillListRequest
{
    [JsonPropertyName("begin_time")] public long BeginTime { get; set; }
    [JsonPropertyName("end_time")] public long EndTime { get; set; }
    [JsonPropertyName("payee_userid")] public string? PayeeUserId { get; set; }
    [JsonPropertyName("cursor")] public string Cursor { get; set; } = string.Empty;
    [JsonPropertyName("limit")] public int Limit { get; set; } = 100;
}

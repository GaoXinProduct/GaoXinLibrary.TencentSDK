using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CorpPay;

/// <summary>获取对外收款记录响应</summary>
public sealed class GetExternalPayBillListResponse : WecomBaseResponse
{
    [JsonPropertyName("bill_list")] public BillItem[]? BillList { get; set; }
    [JsonPropertyName("next_cursor")] public string? NextCursor { get; set; }
}

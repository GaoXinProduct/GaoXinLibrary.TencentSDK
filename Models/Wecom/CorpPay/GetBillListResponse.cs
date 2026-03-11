using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CorpPay;

/// <summary>获取对外收款记录响应</summary>
public class GetBillListResponse : WecomBaseResponse
{
    /// <summary>收款记录列表</summary>
    [JsonPropertyName("bill_list")] public BillItem[]? BillList { get; set; }

    /// <summary>分页游标</summary>
    [JsonPropertyName("next_cursor")] public string? NextCursor { get; set; }
}

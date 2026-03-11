using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Invoice;

/// <summary>电子发票信息</summary>
public class InvoiceInfo
{
    /// <summary>发票抬头</summary>
    [JsonPropertyName("title")] public string? Title { get; set; }

    /// <summary>发票类型，增值税普通/专用发票</summary>
    [JsonPropertyName("billing_type")] public string? BillingType { get; set; }

    /// <summary>发票号码</summary>
    [JsonPropertyName("billing_no")] public string? BillingNo { get; set; }

    /// <summary>发票代码</summary>
    [JsonPropertyName("billing_code")] public string? BillingCode { get; set; }

    /// <summary>税号</summary>
    [JsonPropertyName("tax_no")] public string? TaxNo { get; set; }

    /// <summary>不含税金额（分）</summary>
    [JsonPropertyName("fee_without_tax")] public int FeeWithoutTax { get; set; }

    /// <summary>税额（分）</summary>
    [JsonPropertyName("tax")] public int Tax { get; set; }

    /// <summary>合计金额（分）</summary>
    [JsonPropertyName("total_fee")] public int TotalFee { get; set; }

    /// <summary>开票日期</summary>
    [JsonPropertyName("billing_time")] public long BillingTime { get; set; }

    /// <summary>发票状态，1-正常，2-已作废，3-已红冲</summary>
    [JsonPropertyName("state")] public int State { get; set; }

    /// <summary>校验码</summary>
    [JsonPropertyName("check_code")] public string? CheckCode { get; set; }
}

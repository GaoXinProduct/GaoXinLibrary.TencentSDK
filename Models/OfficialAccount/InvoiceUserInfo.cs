using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 发票用户信息结构
/// </summary>
public class InvoiceUserInfo
{
    [JsonPropertyName("fee")] public int? Fee { get; set; }
    [JsonPropertyName("title")] public string? Title { get; set; }
    [JsonPropertyName("billing_time")] public long? BillingTime { get; set; }
    [JsonPropertyName("billing_no")] public string? BillingNo { get; set; }
    [JsonPropertyName("billing_code")] public string? BillingCode { get; set; }
    [JsonPropertyName("info")] public List<InvoiceCommodityItem>? Info { get; set; }
    [JsonPropertyName("fee_without_tax")] public int? FeeWithoutTax { get; set; }
    [JsonPropertyName("tax")] public int? Tax { get; set; }
    [JsonPropertyName("s_pdf_media_id")] public string? SPdfMediaId { get; set; }
    [JsonPropertyName("s_trip_pdf_media_id")] public string? STripPdfMediaId { get; set; }
    [JsonPropertyName("check_code")] public string? CheckCode { get; set; }
    [JsonPropertyName("buyer_number")] public string? BuyerNumber { get; set; }
    [JsonPropertyName("buyer_address_and_phone")] public string? BuyerAddressAndPhone { get; set; }
    [JsonPropertyName("buyer_bank_account")] public string? BuyerBankAccount { get; set; }
    [JsonPropertyName("seller_number")] public string? SellerNumber { get; set; }
    [JsonPropertyName("seller_address_and_phone")] public string? SellerAddressAndPhone { get; set; }
    [JsonPropertyName("seller_bank_account")] public string? SellerBankAccount { get; set; }
    [JsonPropertyName("remarks")] public string? Remarks { get; set; }
    [JsonPropertyName("cashier")] public string? Cashier { get; set; }
    [JsonPropertyName("maker")] public string? Maker { get; set; }
}

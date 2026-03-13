using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Invoice;

/// <summary>发票卡券标识</summary>
public class InvoiceCardItem
{
    /// <summary>卡券 ID</summary>
    [JsonPropertyName("card_id")]
    public string CardId { get; set; } = string.Empty;

    /// <summary>加密码</summary>
    [JsonPropertyName("encrypt_code")]
    public string EncryptCode { get; set; } = string.Empty;
}

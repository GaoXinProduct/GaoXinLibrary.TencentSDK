using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Invoice;

/// <summary>更新发票状态请求</summary>
public class UpdateInvoiceStatusRequest
{
    /// <summary>卡券 ID</summary>
    [JsonPropertyName("card_id")]
    public string CardId { get; set; } = string.Empty;

    /// <summary>加密码</summary>
    [JsonPropertyName("encrypt_code")]
    public string EncryptCode { get; set; } = string.Empty;

    /// <summary>报销状态</summary>
    [JsonPropertyName("reimburse_status")]
    public int ReimburseStatus { get; set; }
}

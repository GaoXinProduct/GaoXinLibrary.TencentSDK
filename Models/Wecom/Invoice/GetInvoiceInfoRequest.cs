using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Invoice;

/// <summary>获取发票信息请求</summary>
public class GetInvoiceInfoRequest
{
    /// <summary>卡券 ID</summary>
    [JsonPropertyName("card_id")]
    public string CardId { get; set; } = string.Empty;

    /// <summary>加密码</summary>
    [JsonPropertyName("encrypt_code")]
    public string EncryptCode { get; set; } = string.Empty;
}

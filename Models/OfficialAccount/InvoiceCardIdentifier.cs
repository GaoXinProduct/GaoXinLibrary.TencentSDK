using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 发票卡券标识
/// </summary>
public class InvoiceCardIdentifier
{
    /// <summary>发票卡券 card_id</summary>
    [JsonPropertyName("card_id")] public required string CardId { get; set; }

    /// <summary>发票卡券加密 code</summary>
    [JsonPropertyName("encrypt_code")] public required string EncryptCode { get; set; }
}

using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 发票插卡扩展信息
/// </summary>
public class InvoiceCardExt
{
    /// <summary>随机字符串</summary>
    [JsonPropertyName("nonce_str")] public string? NonceStr { get; set; }

    /// <summary>用户发票信息</summary>
    [JsonPropertyName("user_card")] public InvoiceUserInfo? UserCard { get; set; }

    /// <summary>用户发票信息（兼容部分文档字段名）</summary>
    [JsonPropertyName("invoice_user_data")] public InvoiceUserInfo? InvoiceUserData { get; set; }
}

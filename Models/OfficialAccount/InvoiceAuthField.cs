using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 发票授权页字段
/// </summary>
public class InvoiceAuthField
{
    /// <summary>授权页个人发票字段</summary>
    [JsonPropertyName("user_field")] public InvoiceUserField? UserField { get; set; }

    /// <summary>授权页单位发票字段</summary>
    [JsonPropertyName("biz_field")] public InvoiceBizField? BizField { get; set; }
}

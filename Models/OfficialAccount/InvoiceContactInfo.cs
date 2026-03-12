using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 商户联系方式信息
/// </summary>
public class InvoiceContactInfo
{
    /// <summary>开票超时时间</summary>
    [JsonPropertyName("time_out")] public int TimeOut { get; set; }

    /// <summary>联系电话</summary>
    [JsonPropertyName("phone")] public required string Phone { get; set; }
}

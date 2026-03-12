using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 查询发票授权信息响应
/// </summary>
public class InvoiceAuthDataResponse : WechatBaseResponse
{
    /// <summary>发票状态</summary>
    [JsonPropertyName("invoice_status")] public string? InvoiceStatus { get; set; }

    /// <summary>授权时间戳</summary>
    [JsonPropertyName("auth_time")] public long? AuthTime { get; set; }
}

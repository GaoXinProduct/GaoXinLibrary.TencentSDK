using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 获取发票授权页链接响应
/// </summary>
public class InvoiceGetAuthUrlResponse : WechatBaseResponse
{
    /// <summary>授权链接</summary>
    [JsonPropertyName("auth_url")] public string? AuthUrl { get; set; }

    /// <summary>小程序场景返回的 appid</summary>
    [JsonPropertyName("appid")] public string? AppId { get; set; }
}

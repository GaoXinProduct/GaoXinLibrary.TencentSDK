using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 获取商户专属抬头链接响应
/// </summary>
public class InvoiceGetSelectTitleUrlResponse : WechatBaseResponse
{
    [JsonPropertyName("url")] public string? Url { get; set; }
}

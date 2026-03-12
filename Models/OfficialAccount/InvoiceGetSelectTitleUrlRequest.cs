using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 获取商户专属抬头链接请求
/// </summary>
public class InvoiceGetSelectTitleUrlRequest
{
    [JsonPropertyName("attach")] public string? Attach { get; set; }
    [JsonPropertyName("biz_name")] public string? BizName { get; set; }
}

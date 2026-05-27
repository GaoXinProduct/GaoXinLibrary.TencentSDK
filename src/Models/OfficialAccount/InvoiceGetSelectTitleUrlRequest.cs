using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 获取商户专属抬头链接请求
/// </summary>
public sealed class InvoiceGetSelectTitleUrlRequest
{
    [JsonPropertyName("attach")] public string? Attach { get; set; }
    [JsonPropertyName("biz_name")] public string? BizName { get; set; }
}

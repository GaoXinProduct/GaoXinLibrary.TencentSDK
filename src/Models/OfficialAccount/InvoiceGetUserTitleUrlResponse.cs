using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 录入抬头到用户微信响应
/// </summary>
public sealed class InvoiceGetUserTitleUrlResponse : WechatBaseResponse
{
    [JsonPropertyName("url")] public string? Url { get; set; }
}

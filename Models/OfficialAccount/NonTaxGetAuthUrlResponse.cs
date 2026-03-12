using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 获取非税票据授权页链接响应
/// </summary>
public class NonTaxGetAuthUrlResponse : WechatBaseResponse
{
    [JsonPropertyName("auth_url")] public string? AuthUrl { get; set; }
    [JsonPropertyName("expire_time")] public int? ExpireTime { get; set; }
}

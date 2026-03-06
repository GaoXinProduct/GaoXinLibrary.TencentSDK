using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>
/// 使用AppSecret重置API调用次数请求（POST /cgi-bin/clear_quota/v2）
/// </summary>
public class ClearQuotaByAppSecretRequest
{
    /// <summary>小程序的 AppId</summary>
    [JsonPropertyName("appid")] public required string AppId { get; set; }
    /// <summary>小程序的 AppSecret</summary>
    [JsonPropertyName("appsecret")] public required string AppSecret { get; set; }
}

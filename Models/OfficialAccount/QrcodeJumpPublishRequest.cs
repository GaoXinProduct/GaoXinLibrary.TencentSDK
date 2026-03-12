using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 发布二维码规则请求
/// </summary>
public class QrcodeJumpPublishRequest
{
    /// <summary>二维码规则前缀</summary>
    [JsonPropertyName("prefix")] public required string Prefix { get; set; }
}

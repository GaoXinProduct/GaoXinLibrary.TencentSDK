using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 删除二维码规则请求
/// </summary>
public class QrcodeJumpDeleteRequest
{
    /// <summary>二维码规则前缀</summary>
    [JsonPropertyName("prefix")] public required string Prefix { get; set; }

    /// <summary>小程序 AppId（服务号场景可能需要）</summary>
    [JsonPropertyName("appid")] public string? AppId { get; set; }
}

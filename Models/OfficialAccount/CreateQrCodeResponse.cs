using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 创建公众号带参二维码响应（POST /cgi-bin/qrcode/create）
/// </summary>
public class CreateQrCodeResponse : WechatBaseResponse
{
    /// <summary>二维码 ticket，可用于换取二维码图片</summary>
    [JsonPropertyName("ticket")] public string? Ticket { get; set; }

    /// <summary>二维码有效期（秒，仅临时二维码返回）</summary>
    [JsonPropertyName("expire_seconds")] public int? ExpireSeconds { get; set; }

    /// <summary>二维码解析地址</summary>
    [JsonPropertyName("url")] public string? Url { get; set; }
}

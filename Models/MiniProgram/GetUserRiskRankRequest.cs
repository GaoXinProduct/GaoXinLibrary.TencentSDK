using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 获取用户安全等级请求（POST /wxa/getuserriskrank）
/// </summary>
public class GetUserRiskRankRequest
{
    /// <summary>小程序 AppId</summary>
    [JsonPropertyName("appid")] public required string AppId { get; set; }
    /// <summary>用户的 OpenId</summary>
    [JsonPropertyName("openid")] public required string OpenId { get; set; }
    /// <summary>场景值（0 注册；1 营销活动）</summary>
    [JsonPropertyName("scene")] public int Scene { get; set; }
    /// <summary>用户手机号</summary>
    [JsonPropertyName("mobile_no")] public string? MobileNo { get; set; }
    /// <summary>用户客户端 IP</summary>
    [JsonPropertyName("client_ip")] public string? ClientIp { get; set; }
    /// <summary>用户邮箱地址</summary>
    [JsonPropertyName("email_address")] public string? EmailAddress { get; set; }
    /// <summary>额外补充信息</summary>
    [JsonPropertyName("extended_info")] public string? ExtendedInfo { get; set; }
}


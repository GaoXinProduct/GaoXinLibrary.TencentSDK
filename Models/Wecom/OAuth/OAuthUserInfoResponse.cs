using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.OAuth;

// ─── 获取访问用户身份 ─────────────────────────────────────────────────────

/// <summary>
/// 获取访问用户身份响应（GET /cgi-bin/auth/getuserinfo）
/// </summary>
public class OAuthUserInfoResponse : WecomBaseResponse
{
    /// <summary>
    /// 成员 UserID；若需要获取用户详情信息，可在获取用户信息后再使用此字段
    /// </summary>
    [JsonPropertyName("userid")] public string? UserId { get; set; }

    /// <summary>
    /// 成员票据，最大长度为512字节；<br/>
    /// scope 为 snsapi_privateinfo 时，用于换取成员详情信息，有效期5分钟
    /// </summary>
    [JsonPropertyName("user_ticket")] public string? UserTicket { get; set; }

    /// <summary>
    /// 非企业成员的 OpenId（仅当成员为企业外部成员时返回）
    /// </summary>
    [JsonPropertyName("openid")] public string? OpenId { get; set; }

    /// <summary>
    /// 外部成员的 ExternalUserId（仅当成员在企业外部时返回）
    /// </summary>
    [JsonPropertyName("external_userid")] public string? ExternalUserId { get; set; }

    /// <summary>
    /// 企业成员的 OpenUserId（全局唯一，不随企业变化）
    /// </summary>
    [JsonPropertyName("open_userid")] public string? OpenUserId { get; set; }

    /// <summary>
    /// 设备号（企业微信 2.8.0+ 仅在聚合应用且开启设备管理时返回）
    /// </summary>
    [JsonPropertyName("deviceid")] public string? DeviceId { get; set; }
}


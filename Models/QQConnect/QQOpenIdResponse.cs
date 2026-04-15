using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.QQConnect;

#region 获取用户 OpenID

/// <summary>
/// 获取用户 OpenID 响应
/// <para>
/// 对应接口：GET https://graph.qq.com/oauth2.0/me
/// </para>
/// </summary>
public class QQOpenIdResponse : QQBaseResponse
{
    /// <summary>应用的 AppID</summary>
    [JsonPropertyName("client_id")] public string? ClientId { get; set; }

    /// <summary>用户在该应用的唯一标识</summary>
    [JsonPropertyName("openid")] public string? OpenId { get; set; }

    /// <summary>用户统一标识（UnionID 机制）</summary>
    [JsonPropertyName("unionid")] public string? UnionId { get; set; }
}

#endregion

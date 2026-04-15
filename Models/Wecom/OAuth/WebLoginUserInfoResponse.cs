using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.OAuth;

#region 获取用户登录身份（Web 登录）

/// <summary>
/// 获取用户登录身份响应（GET /cgi-bin/auth/getuserinfo — Web 登录场景）
/// <para>
/// 与 <see cref="OAuthUserInfoResponse"/> 使用相同接口地址，但 Web 登录场景下
/// 仅返回 <c>userid</c>（企业成员）或 <c>openid</c> + <c>external_userid</c>（非企业成员），
/// 不包含 <c>user_ticket</c>、<c>open_userid</c>、<c>deviceid</c> 等字段。<br/>
/// 参见：<see href="https://developer.work.weixin.qq.com/document/path/98176"/>
/// </para>
/// </summary>
public class WebLoginUserInfoResponse : WecomBaseResponse
{
    /// <summary>
    /// 企业成员的 UserID（仅企业成员登录时返回）
    /// </summary>
    [JsonPropertyName("userid")] public string? UserId { get; set; }

    /// <summary>
    /// 非企业成员的 OpenId（仅非企业成员登录时返回）
    /// </summary>
    [JsonPropertyName("openid")] public string? OpenId { get; set; }

    /// <summary>
    /// 外部成员的 ExternalUserId（仅非企业成员登录时返回）
    /// </summary>
    [JsonPropertyName("external_userid")] public string? ExternalUserId { get; set; }
}

#endregion

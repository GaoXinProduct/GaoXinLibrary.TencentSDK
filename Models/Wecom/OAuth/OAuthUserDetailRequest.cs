using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.OAuth;

#region 获取用户敏感信息

/// <summary>
/// 获取用户敏感信息请求（POST /cgi-bin/auth/getuserdetail）
/// </summary>
public class OAuthUserDetailRequest
{
    /// <summary>
    /// 成员票据，由 <see cref="OAuthUserInfoResponse.UserTicket"/> 获取；有效期5分钟
    /// </summary>
    [JsonPropertyName("user_ticket")] public required string UserTicket { get; set; }
}

#endregion

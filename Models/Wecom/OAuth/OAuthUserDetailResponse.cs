using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.OAuth;

/// <summary>
/// 获取用户敏感信息响应（POST /cgi-bin/auth/getuserdetail）
/// </summary>
public class OAuthUserDetailResponse : WecomBaseResponse
{
    /// <summary>企业 CorpId</summary>
    [JsonPropertyName("corpid")] public string? CorpId { get; set; }

    /// <summary>成员 UserID</summary>
    [JsonPropertyName("userid")] public string? UserId { get; set; }

    /// <summary>成员姓名</summary>
    [JsonPropertyName("name")] public string? Name { get; set; }

    /// <summary>
    /// 手机号码；需成员已授权且企业开启了手机号可见
    /// </summary>
    [JsonPropertyName("mobile")] public string? Mobile { get; set; }

    /// <summary>
    /// 性别；0=未设置，1=男，2=女
    /// </summary>
    [JsonPropertyName("gender")] public string? Gender { get; set; }

    /// <summary>邮箱地址</summary>
    [JsonPropertyName("email")] public string? Email { get; set; }

    /// <summary>企业邮箱（biz_mail）</summary>
    [JsonPropertyName("biz_mail")] public string? BizMail { get; set; }

    /// <summary>头像 URL（大小为 132×132，需成员已设置头像）</summary>
    [JsonPropertyName("avatar")] public string? Avatar { get; set; }

    /// <summary>员工个人二维码 URL（扫描可添加为外部联系人）</summary>
    [JsonPropertyName("qr_code")] public string? QrCode { get; set; }

    /// <summary>地址（需成员已授权）</summary>
    [JsonPropertyName("address")] public string? Address { get; set; }
}


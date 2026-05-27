using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Email;

/// <summary>查询应用邮箱账号响应</summary>
/// <remarks>
/// 文档路径: /document/path/97991
/// </remarks>
public class GetEmailAccountResponse : WecomBaseResponse
{
    /// <summary>用户userid</summary>
    [JsonPropertyName("userid")]
    public string? UserId { get; set; }

    /// <summary>邮箱账号类型，1=管理员绑定邮箱，2=邮箱前缀匹配</summary>
    [JsonPropertyName("email_type")]
    public int EmailType { get; set; }

    /// <summary>邮箱账号</summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }
}
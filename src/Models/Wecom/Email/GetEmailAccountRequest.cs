using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Email;

/// <summary>查询应用邮箱账号请求</summary>
/// <remarks>
/// 文档路径: /document/path/97991
/// </remarks>
public record GetEmailAccountRequest
{
    /// <summary>旧版成员字段。查询使用当前应用的身份。</summary>
    [Obsolete("应用邮件账号查询不接受成员 userid。")]
    [JsonIgnore]
    public string UserId { get; set; } = string.Empty;
}

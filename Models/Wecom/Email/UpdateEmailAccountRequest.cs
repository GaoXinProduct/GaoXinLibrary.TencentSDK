using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Email;

/// <summary>更新应用邮箱账号请求</summary>
/// <remarks>
/// 文档路径: /document/path/97373
/// </remarks>
public record UpdateEmailAccountRequest
{
    /// <summary>用户userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; set; } = string.Empty;

    /// <summary>邮箱账号类型，1=管理员绑定邮箱，2=邮箱前缀匹配</summary>
    [JsonPropertyName("email_type")]
    public int? EmailType { get; set; }

    /// <summary>需要绑定的邮箱账号</summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>是否需要重置密码，1=需要，0=不需要</summary>
    [JsonPropertyName("reset_password")]
    public int? ResetPassword { get; set; }

    /// <summary>是否新建邮箱文件夹，1=新建，0=不新建</summary>
    [JsonPropertyName("new_folder")]
    public int? NewFolder { get; set; }
}
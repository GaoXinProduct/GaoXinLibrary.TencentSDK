using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Email;

/// <summary>更新应用邮箱账号请求</summary>
/// <remarks>
/// 文档路径: /document/path/97373
/// </remarks>
public record UpdateEmailAccountRequest
{
    /// <summary>旧版成员字段。此接口管理应用自己的邮箱。</summary>
    [Obsolete("应用邮箱更新不接受成员 userid。")]
    [JsonIgnore]
    public string UserId { get; set; } = string.Empty;

    /// <summary>邮箱账号类型，1=管理员绑定邮箱，2=邮箱前缀匹配</summary>
    [Obsolete("应用邮箱更新不接受邮箱类型。")]
    [JsonIgnore]
    public int? EmailType { get; set; }

    /// <summary>修改后的应用邮箱账号。原有地址会保留为收信别名。</summary>
    [JsonPropertyName("new_email")]
    public string? NewEmail { get; set; }

    /// <summary><see cref="NewEmail"/> 的兼容属性。</summary>
    [JsonIgnore]
    public string? Email { get => NewEmail; set => NewEmail = value; }

    /// <summary>是否需要重置密码，1=需要，0=不需要</summary>
    [Obsolete("应用邮箱更新不支持重置密码。")]
    [JsonIgnore]
    public int? ResetPassword { get; set; }

    /// <summary>是否新建邮箱文件夹，1=新建，0=不新建</summary>
    [Obsolete("应用邮箱更新不支持新建邮箱文件夹。")]
    [JsonIgnore]
    public int? NewFolder { get; set; }
}

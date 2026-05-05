using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Email;

/// <summary>查询应用邮箱账号请求</summary>
/// <remarks>
/// 文档路径: /document/path/97991
/// </remarks>
public record GetEmailAccountRequest
{
    /// <summary>用户userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; set; } = string.Empty;
}
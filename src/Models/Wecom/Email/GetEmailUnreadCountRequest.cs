using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Email;

/// <summary>获取邮件未读数请求</summary>
/// <remarks>文档路径: /document/path/95514</remarks>
public record GetEmailUnreadCountRequest
{
    /// <summary>用户userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; set; } = string.Empty;
}
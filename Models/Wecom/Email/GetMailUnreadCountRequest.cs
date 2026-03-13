using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Email;

/// <summary>获取邮件未读数请求</summary>
public class GetMailUnreadCountRequest
{
    /// <summary>用户 userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; set; } = string.Empty;
}

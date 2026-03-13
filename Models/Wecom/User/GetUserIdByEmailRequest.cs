using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.User;

/// <summary>通过邮箱获取 userid 请求</summary>
public class GetUserIdByEmailRequest
{
    /// <summary>邮箱</summary>
    [JsonPropertyName("email")]
    public string Email { get; set; } = string.Empty;

    /// <summary>邮箱类型，1-企业邮箱，2-个人邮箱</summary>
    [JsonPropertyName("email_type")]
    public int EmailType { get; set; } = 1;
}

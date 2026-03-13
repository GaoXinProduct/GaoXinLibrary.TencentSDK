using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.User;

/// <summary>openid 转 userid 请求</summary>
public class ConvertToUserIdRequest
{
    /// <summary>用户 openid</summary>
    [JsonPropertyName("openid")]
    public string OpenId { get; set; } = string.Empty;
}

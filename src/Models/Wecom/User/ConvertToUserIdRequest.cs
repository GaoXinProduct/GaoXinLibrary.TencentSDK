
namespace GaoXinLibrary.TencentSDK.Wecom.Models.User;

/// <summary>openid 转 userid 请求</summary>
public sealed class ConvertToUserIdRequest
{
    /// <summary>用户 openid</summary>
    [JsonPropertyName("openid")]
    public string OpenId { get; set; } = string.Empty;
}

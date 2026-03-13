using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.User;

/// <summary>userid 转 openid 请求</summary>
public class ConvertToOpenIdRequest
{
    /// <summary>用户 userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; set; } = string.Empty;
}

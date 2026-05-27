using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Email;

/// <summary>获取客户端专用密码列表请求</summary>
/// <remarks>文档路径: /document/path/100180</remarks>
public record GetClientSecretRequest
{
    /// <summary>用户userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; set; } = string.Empty;
}
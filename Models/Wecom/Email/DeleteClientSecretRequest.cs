using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Email;

/// <summary>删除客户端专用密码请求</summary>
/// <remarks>文档路径: /document/path/100184</remarks>
public record DeleteClientSecretRequest
{
    /// <summary>用户userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; set; } = string.Empty;

    /// <summary>客户端专用密码ID</summary>
    [JsonPropertyName("client_secret_id")]
    public string ClientSecretId { get; set; } = string.Empty;
}
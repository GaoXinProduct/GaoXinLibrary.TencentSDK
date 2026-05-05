using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Email;

/// <summary>获取客户端专用密码列表响应</summary>
/// <remarks>文档路径: /document/path/100180</remarks>
public class GetClientSecretResponse : WecomBaseResponse
{
    /// <summary>客户端专用密码列表</summary>
    [JsonPropertyName("client_secret_list")]
    public ClientSecretItem[]? ClientSecretList { get; set; }
}

/// <summary>客户端专用密码项</summary>
public record ClientSecretItem
{
    /// <summary>客户端专用密码ID</summary>
    [JsonPropertyName("client_secret_id")]
    public string? ClientSecretId { get; set; }

    /// <summary>客户端专用密码创建时间</summary>
    [JsonPropertyName("create_time")]
    public long CreateTime { get; set; }
}
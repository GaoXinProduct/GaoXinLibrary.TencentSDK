using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.AsyncImport;

/// <summary>异步导入回调信息</summary>
public class AsyncImportCallback
{
    /// <summary>企业应用接收企业微信推送请求的访问协议和地址</summary>
    [JsonPropertyName("url")] public string Url { get; set; } = string.Empty;

    /// <summary>用于生成签名</summary>
    [JsonPropertyName("token")] public string Token { get; set; } = string.Empty;

    /// <summary>用于消息体的加密</summary>
    [JsonPropertyName("encodingaeskey")] public string EncodingAesKey { get; set; } = string.Empty;
}

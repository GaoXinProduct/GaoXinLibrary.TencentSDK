using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>
/// 生成 URL Link 请求（POST /wxa/generate_urllink）
/// </summary>
public class GenerateUrlLinkRequest
{
    /// <summary>小程序页面路径</summary>
    [JsonPropertyName("path")] public string? Path { get; set; }

    /// <summary>小程序页面参数</summary>
    [JsonPropertyName("query")] public string? Query { get; set; }

    /// <summary>是否到期失效</summary>
    [JsonPropertyName("is_expire")] public bool? IsExpire { get; set; }

    /// <summary>失效时间（Unix 时间戳）</summary>
    [JsonPropertyName("expire_time")] public long? ExpireTime { get; set; }

    /// <summary>失效间隔天数</summary>
    [JsonPropertyName("expire_interval")] public int? ExpireInterval { get; set; }

    /// <summary>失效类型（0 指定时间戳失效；1 指定间隔天数失效）</summary>
    [JsonPropertyName("expire_type")] public int? ExpireType { get; set; }

    /// <summary>环境版本（release/trial/develop）</summary>
    [JsonPropertyName("env_version")] public string? EnvVersion { get; set; }
}


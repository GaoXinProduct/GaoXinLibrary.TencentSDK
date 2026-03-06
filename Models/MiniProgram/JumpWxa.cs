using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>小程序跳转信息</summary>
public class JumpWxa
{
    /// <summary>小程序页面路径</summary>
    [JsonPropertyName("path")] public string? Path { get; set; }

    /// <summary>小程序页面参数</summary>
    [JsonPropertyName("query")] public string? Query { get; set; }

    /// <summary>环境版本（release/trial/develop）</summary>
    [JsonPropertyName("env_version")] public string? EnvVersion { get; set; }
}


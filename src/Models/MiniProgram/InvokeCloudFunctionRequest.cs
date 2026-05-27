using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 触发云函数请求（POST /tcb/invoke_cloud_function）
/// </summary>
public sealed class InvokeCloudFunctionRequest
{
    /// <summary>云开发环境ID</summary>
    [JsonPropertyName("env")] public required string Env { get; set; }
    /// <summary>云函数名称</summary>
    [JsonPropertyName("name")] public required string Name { get; set; }
    /// <summary>云函数接收的参数（JSON字符串）</summary>
    [JsonPropertyName("body")] public string? Body { get; set; }
}
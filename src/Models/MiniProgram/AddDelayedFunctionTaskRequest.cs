using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 延时调用云函数请求（POST /tcb/add_delayed_function_task）
/// </summary>
public sealed class AddDelayedFunctionTaskRequest
{
    [JsonPropertyName("env")] public required string Env { get; set; }
    [JsonPropertyName("name")] public required string Name { get; set; }
    [JsonPropertyName("body")] public string? Body { get; set; }
    /// <summary>延迟时间（毫秒）</summary>
    [JsonPropertyName("delay")] public int Delay { get; set; }
}
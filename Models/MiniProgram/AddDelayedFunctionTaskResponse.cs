using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 延时调用云函数响应
/// </summary>
public sealed class AddDelayedFunctionTaskResponse : WechatBaseResponse
{
    [JsonPropertyName("task_id")] public string? TaskId { get; init; }
}
using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 配置面单打印员响应
/// </summary>
public sealed class UpdatePrinterResponse : WechatBaseResponse
{
    /// <summary>打印机ID</summary>
    [JsonPropertyName("printer_id")] public string? PrinterId { get; init; }
    /// <summary>更新结果</summary>
    [JsonPropertyName("result")] public string? Result { get; init; }
}
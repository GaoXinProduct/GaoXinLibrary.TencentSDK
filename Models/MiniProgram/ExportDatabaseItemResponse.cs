using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 数据库导出响应
/// </summary>
public sealed class ExportDatabaseItemResponse : WechatBaseResponse
{
    [JsonPropertyName("job_id")] public string? JobId { get; init; }
}
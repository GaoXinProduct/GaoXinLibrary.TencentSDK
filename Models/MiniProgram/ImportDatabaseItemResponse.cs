using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 数据库导入响应
/// </summary>
public sealed class ImportDatabaseItemResponse : WechatBaseResponse
{
    [JsonPropertyName("job_id")] public string? JobId { get; init; }
}
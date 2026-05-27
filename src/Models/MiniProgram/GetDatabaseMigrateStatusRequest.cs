using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 数据库迁移状态查询请求（POST /tcb/database_migrate_query）
/// </summary>
public sealed class GetDatabaseMigrateStatusRequest
{
    [JsonPropertyName("env")] public required string Env { get; set; }
    [JsonPropertyName("job_id")] public required string JobId { get; set; }
}
using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 数据库导入请求（POST /tcb/database_migrate_import）
/// </summary>
public sealed class ImportDatabaseItemRequest
{
    [JsonPropertyName("env")] public required string Env { get; set; }
    [JsonPropertyName("collection_name")] public required string CollectionName { get; set; }
    [JsonPropertyName("file_path")] public required string FilePath { get; set; }
    /// <summary>导入类型（1插入 2upsert）</summary>
    [JsonPropertyName("operation_type")] public required int OperationType { get; set; }
}
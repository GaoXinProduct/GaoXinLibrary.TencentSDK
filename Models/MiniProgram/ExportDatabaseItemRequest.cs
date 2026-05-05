using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 数据库导出请求（POST /tcb/database_migrate_export）
/// </summary>
public sealed class ExportDatabaseItemRequest
{
    [JsonPropertyName("env")] public required string Env { get; set; }
    [JsonPropertyName("collection_name")] public required string CollectionName { get; set; }
    /// <summary>查询条件</summary>
    [JsonPropertyName("query")] public string? Query { get; set; }
    /// <summary>导出类型（json/csv）</summary>
    [JsonPropertyName("file_type")] public required string FileType { get; set; }
    /// <summary>导出文件路径</summary>
    [JsonPropertyName("file_path")] public required string FilePath { get; set; }
}
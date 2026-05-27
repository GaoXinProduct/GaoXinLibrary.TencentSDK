using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 更新数据库索引请求（POST /tcb/database_index_update）
/// </summary>
public sealed class UpdateDatabaseIndexRequest
{
    [JsonPropertyName("env")] public required string Env { get; set; }
    [JsonPropertyName("collection_name")] public required string CollectionName { get; set; }
    /// <summary>索引配置</summary>
    [JsonPropertyName("indexes")] public required List<IndexConfig> Indexes { get; set; }
}

/// <summary>
/// 索引配置
/// </summary>
public sealed class IndexConfig
{
    [JsonPropertyName("name")] public required string Name { get; set; }
    [JsonPropertyName("fields")] public required List<IndexField> Fields { get; set; }
}

/// <summary>
/// 索引字段
/// </summary>
public sealed class IndexField
{
    [JsonPropertyName("field")] public required string Field { get; set; }
    /// <summary>1升序 -1降序</summary>
    [JsonPropertyName("order")] public required int Order { get; set; }
}
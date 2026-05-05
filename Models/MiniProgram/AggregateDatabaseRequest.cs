using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 数据库聚合请求（POST /tcb/database_aggregate）
/// </summary>
public sealed class AggregateDatabaseRequest
{
    [JsonPropertyName("env")] public required string Env { get; set; }
    [JsonPropertyName("collection_name")] public required string CollectionName { get; set; }
    /// <summary>聚合管道（JSON字符串）</summary>
    [JsonPropertyName("query")] public required string Query { get; set; }
}
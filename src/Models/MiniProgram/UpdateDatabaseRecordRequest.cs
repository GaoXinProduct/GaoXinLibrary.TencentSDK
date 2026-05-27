using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 数据库更新记录请求（POST /tcb/database_update）
/// </summary>
public sealed class UpdateDatabaseRecordRequest
{
    [JsonPropertyName("env")] public required string Env { get; set; }
    [JsonPropertyName("collection_name")] public required string CollectionName { get; set; }
    /// <summary>记录ID</summary>
    [JsonPropertyName("id")] public required string Id { get; set; }
    /// <summary>更新数据（JSON对象）</summary>
    [JsonPropertyName("data")] public required Dictionary<string, object> Data { get; set; }
}
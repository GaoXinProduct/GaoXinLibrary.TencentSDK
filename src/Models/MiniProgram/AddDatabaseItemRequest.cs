using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 数据库插入记录请求（POST /tcb/database_insert）
/// </summary>
public sealed class AddDatabaseItemRequest
{
    [JsonPropertyName("env")] public required string Env { get; set; }
    [JsonPropertyName("collection_name")] public required string CollectionName { get; set; }
    /// <summary>记录数据（JSON对象）</summary>
    [JsonPropertyName("data")] public required Dictionary<string, object> Data { get; set; }
}
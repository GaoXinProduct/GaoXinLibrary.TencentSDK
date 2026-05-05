using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 数据库删除记录请求（POST /tcb/database_delete）
/// </summary>
public sealed class DeleteDatabaseItemRequest
{
    [JsonPropertyName("env")] public required string Env { get; set; }
    [JsonPropertyName("collection_name")] public required string CollectionName { get; set; }
    [JsonPropertyName("id")] public required string Id { get; set; }
}
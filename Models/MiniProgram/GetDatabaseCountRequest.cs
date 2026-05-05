using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 统计集合记录数请求（POST /tcb/database_count）
/// </summary>
public sealed class GetDatabaseCountRequest
{
    [JsonPropertyName("env")] public required string Env { get; set; }
    [JsonPropertyName("collection_name")] public required string CollectionName { get; set; }
    [JsonPropertyName("query")] public string? Query { get; set; }
}
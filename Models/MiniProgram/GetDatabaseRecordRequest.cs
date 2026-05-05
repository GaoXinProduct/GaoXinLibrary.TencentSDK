using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 数据库查询记录请求（POST /tcb/database_query）
/// </summary>
public sealed class GetDatabaseRecordRequest
{
    [JsonPropertyName("env")] public required string Env { get; set; }
    [JsonPropertyName("collection_name")] public required string CollectionName { get; set; }
    /// <summary>查询条件（JSON字符串）</summary>
    [JsonPropertyName("query")] public string? Query { get; set; }
    /// <summary>限制返回数量</summary>
    [JsonPropertyName("limit")] public int Limit { get; set; } = 100;
    /// <summary>跳过数量</summary>
    [JsonPropertyName("offset")] public int Offset { get; set; } = 0;
}
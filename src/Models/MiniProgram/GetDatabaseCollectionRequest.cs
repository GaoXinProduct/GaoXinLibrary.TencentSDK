using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 获取集合信息请求（POST /tcb/database_collection_get）
/// </summary>
public sealed class GetDatabaseCollectionRequest
{
    [JsonPropertyName("env")] public required string Env { get; set; }
}
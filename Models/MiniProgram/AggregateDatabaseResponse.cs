using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 数据库聚合响应
/// </summary>
public sealed class AggregateDatabaseResponse : WechatBaseResponse
{
    [JsonPropertyName("data")] public List<Dictionary<string, object>>? Data { get; init; }
}
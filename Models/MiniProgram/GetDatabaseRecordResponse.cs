using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 数据库查询记录响应
/// </summary>
public sealed class GetDatabaseRecordResponse : WechatBaseResponse
{
    [JsonPropertyName("data")] public List<Dictionary<string, object>>? Data { get; init; }
}
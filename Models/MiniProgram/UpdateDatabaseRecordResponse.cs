using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 数据库更新记录响应
/// </summary>
public sealed class UpdateDatabaseRecordResponse : WechatBaseResponse
{
    /// <summary>更新的记录数</summary>
    [JsonPropertyName("updated")] public int Updated { get; init; }
}
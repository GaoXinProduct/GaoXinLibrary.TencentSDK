using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 数据库迁移状态查询响应
/// </summary>
public sealed class GetDatabaseMigrateStatusResponse : WechatBaseResponse
{
    /// <summary>任务状态（0进行中 1成功 2失败）</summary>
    [JsonPropertyName("status")] public int Status { get; init; }
    /// <summary>导入/导出记录数</summary>
    [JsonPropertyName("records_count")] public long RecordsCount { get; init; }
}
using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 数据库删除记录响应
/// </summary>
public sealed class DeleteDatabaseItemResponse : WechatBaseResponse
{
    /// <summary>删除的记录数</summary>
    [JsonPropertyName("deleted")] public int Deleted { get; init; }
}
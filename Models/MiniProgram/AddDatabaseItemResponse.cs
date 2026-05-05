using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 数据库插入记录响应
/// </summary>
public sealed class AddDatabaseItemResponse : WechatBaseResponse
{
    [JsonPropertyName("id")] public string? Id { get; init; }
}
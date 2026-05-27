using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 统计集合记录数响应
/// </summary>
public sealed class GetDatabaseCountResponse : WechatBaseResponse
{
    /// <summary>记录数</summary>
    [JsonPropertyName("total")] public long Total { get; init; }
}
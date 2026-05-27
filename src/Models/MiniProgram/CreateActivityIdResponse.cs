using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 创建activity_id响应
/// </summary>
public sealed class CreateActivityIdResponse : WechatBaseResponse
{
    /// <summary>activity_id</summary>
    [JsonPropertyName("activity_id")] public string? ActivityId { get; init; }
    /// <summary>过期时间（Unix时间戳）</summary>
    [JsonPropertyName("expiration_time")] public long ExpirationTime { get; init; }
}
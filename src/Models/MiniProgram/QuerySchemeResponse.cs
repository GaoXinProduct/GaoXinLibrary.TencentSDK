using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 查询scheme码响应
/// </summary>
public sealed class QuerySchemeResponse : WechatBaseResponse
{
    /// <summary>scheme内容</summary>
    [JsonPropertyName("scheme")] public string? Scheme { get; init; }

    /// <summary>scheme对应的小程序页面路径</summary>
    [JsonPropertyName("path")] public string? Path { get; init; }

    /// <summary>scheme对应的小程序query参数</summary>
    [JsonPropertyName("query")] public string? Query { get; init; }

    /// <summary>scheme的过期时间（Unix时间戳）</summary>
    [JsonPropertyName("expire_time")] public long ExpireTime { get; init; }

    /// <summary>scheme值类型（临近小程序入口...</summary>
    [JsonPropertyName("jump_type")] public int JumpType { get; init; }

    /// <summary>小程序appid</summary>
    [JsonPropertyName("appid")] public string? AppId { get; init; }
}

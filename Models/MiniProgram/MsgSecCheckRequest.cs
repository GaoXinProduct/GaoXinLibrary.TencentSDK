using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 文本内容安全检测请求（POST /wxa/msg_sec_check）
/// </summary>
public class MsgSecCheckRequest
{
    /// <summary>需检测的文本内容（不超过 500KB）</summary>
    [JsonPropertyName("content")] public required string Content { get; set; }

    /// <summary>接口版本号，固定为 2</summary>
    [JsonPropertyName("version")] public int Version { get; set; } = 2;

    /// <summary>场景值（1 资料；2 评论；3 论坛；4 社交日志）</summary>
    [JsonPropertyName("scene")] public int Scene { get; set; } = 1;

    /// <summary>用户的 OpenId</summary>
    [JsonPropertyName("openid")] public required string OpenId { get; set; }

    /// <summary>文本标题（可选，用于scene=1的情况）</summary>
    [JsonPropertyName("title")] public string? Title { get; set; }

    /// <summary>用户昵称（可选）</summary>
    [JsonPropertyName("nickname")] public string? Nickname { get; set; }

    /// <summary>个性签名（可选）</summary>
    [JsonPropertyName("signature")] public string? Signature { get; set; }
}


using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 生成 URL Scheme 请求（POST /wxa/generatescheme）
/// </summary>
public class GenerateSchemeRequest
{
    /// <summary>跳转到的目标小程序信息</summary>
    [JsonPropertyName("jump_wxa")] public JumpWxa? JumpWxa { get; set; }

    /// <summary>到期失效的 scheme 码（设为 true 时需设置 expire_time 或 expire_interval）</summary>
    [JsonPropertyName("is_expire")] public bool? IsExpire { get; set; }

    /// <summary>到期失效的 scheme 码的失效时间（Unix 时间戳）</summary>
    [JsonPropertyName("expire_time")] public long? ExpireTime { get; set; }

    /// <summary>到期失效的 scheme 码的失效间隔天数（1~365）</summary>
    [JsonPropertyName("expire_interval")] public int? ExpireInterval { get; set; }

    /// <summary>scheme 码类型（默认 0 到期失效；1 永久有效）</summary>
    [JsonPropertyName("expire_type")] public int? ExpireType { get; set; }
}


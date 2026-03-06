using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.QQConnect;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// QQ 互联 OAuth2.0 基础响应
/// <para>
/// QQ 互联接口错误格式与微信不同：
/// OAuth 接口使用 error / error_description 字段；
/// OpenAPI 使用 ret / msg 字段（ret=0 表示成功）。
/// </para>
/// </summary>
public class QQBaseResponse
{
    /// <summary>错误码（OAuth 接口，正常时不返回）</summary>
    [JsonPropertyName("error")] public int Error { get; set; }

    /// <summary>错误描述（OAuth 接口）</summary>
    [JsonPropertyName("error_description")] public string? ErrorDescription { get; set; }
}


using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 校验 session_key 是否有效请求（GET /wxa/checksession）
/// </summary>
public class CheckSessionKeyRequest
{
    /// <summary>用户 OpenId</summary>
    public required string OpenId { get; set; }
    /// <summary>用户的 session_key（此字段不发送到 body，由查询参数传递）</summary>
    public required string SessionKey { get; set; }
}


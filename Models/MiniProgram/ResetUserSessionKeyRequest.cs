using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>
/// 重置 session_key 请求（GET /wxa/resetusersessionkey）
/// </summary>
public class ResetUserSessionKeyRequest
{
    /// <summary>用户 OpenId</summary>
    public required string OpenId { get; set; }
    /// <summary>用户的 session_key</summary>
    public required string SessionKey { get; set; }
}


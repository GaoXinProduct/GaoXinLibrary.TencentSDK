using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>重置 session_key 响应</summary>
public class ResetUserSessionKeyResponse : WechatBaseResponse
{
    /// <summary>用户的 OpenId</summary>
    [JsonPropertyName("openid")] public string? OpenId { get; set; }
    /// <summary>新的 session_key</summary>
    [JsonPropertyName("session_key")] public string? SessionKey { get; set; }
}


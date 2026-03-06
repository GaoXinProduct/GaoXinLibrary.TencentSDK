using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CorpGroup;

/// <summary>获取下级/下游企业 access_token 响应</summary>
public class GetCorpTokenResponse : WecomBaseResponse
{
    /// <summary>下级/下游企业的 access_token</summary>
    [JsonPropertyName("access_token")] public string AccessToken { get; set; } = string.Empty;

    /// <summary>access_token 的有效期（秒）</summary>
    [JsonPropertyName("expires_in")] public int ExpiresIn { get; set; }
}


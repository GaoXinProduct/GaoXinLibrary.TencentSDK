using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CorpGroup;

/// <summary>获取下级/下游企业小程序 session 响应</summary>
public class TransferSessionResponse : WecomBaseResponse
{
    /// <summary>下级/下游企业的 userid</summary>
    [JsonPropertyName("userid")] public string UserId { get; set; } = string.Empty;

    /// <summary>下级/下游企业的 session_key</summary>
    [JsonPropertyName("session_key")] public string SessionKey { get; set; } = string.Empty;
}


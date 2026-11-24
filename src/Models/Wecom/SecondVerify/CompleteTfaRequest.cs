namespace GaoXinLibrary.TencentSDK.Wecom.Models.SecondVerify;

/// <summary>完成使用二次验证的请求。</summary>
public sealed record CompleteTfaRequest
{
    /// <summary>已验证成员的 userid。</summary>
    [JsonPropertyName("userid")] public string UserId { get; init; } = string.Empty;

    /// <summary>获取二次验证信息时返回的一次性授权码。</summary>
    [JsonPropertyName("tfa_code")] public string TfaCode { get; init; } = string.Empty;
}

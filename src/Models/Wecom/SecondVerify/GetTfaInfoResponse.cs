using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SecondVerify;

/// <summary>获取用户二次验证信息响应</summary>
public sealed class GetTfaInfoResponse : WecomBaseResponse
{
    /// <summary>用户userid</summary>
    [JsonPropertyName("userid")] public string? UserId { get; set; }

    /// <summary>用于完成使用二次验证的一次性授权码，有效期为五分钟。</summary>
    [JsonPropertyName("tfa_code")] public string? TfaCode { get; set; }

    /// <summary>服务端返回该字段时的用户状态。</summary>
    [Obsolete("获取二次验证信息接口的正式响应字段为 UserId 和 TfaCode。")]
    [JsonPropertyName("status")] public int Status { get; set; }
}

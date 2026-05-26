using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 长信息转短链响应
/// </summary>
public sealed class ShortLinkGenerateResponse : WechatBaseResponse
{
    /// <summary>短 key</summary>
    [JsonPropertyName("short_key")] public string? ShortKey { get; set; }
}

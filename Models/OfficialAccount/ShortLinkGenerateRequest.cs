using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 长信息转短链请求
/// </summary>
public class ShortLinkGenerateRequest
{
    /// <summary>需要转换的长信息（不超过 4KB）</summary>
    [JsonPropertyName("long_data")] public required string LongData { get; set; }

    /// <summary>过期秒数，最大 2592000（30 天）</summary>
    [JsonPropertyName("expire_seconds")] public int? ExpireSeconds { get; set; }
}

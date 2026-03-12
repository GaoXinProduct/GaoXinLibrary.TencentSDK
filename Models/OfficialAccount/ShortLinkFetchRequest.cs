using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 短链转长信息请求
/// </summary>
public class ShortLinkFetchRequest
{
    /// <summary>短 key</summary>
    [JsonPropertyName("short_key")] public required string ShortKey { get; set; }
}

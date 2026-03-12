using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 获取公众号黑名单列表请求（POST /cgi-bin/tags/members/getblacklist）
/// </summary>
public class GetBlacklistRequest
{
    /// <summary>
    /// 起始 OpenId（默认从开头拉取）
    /// </summary>
    [JsonPropertyName("begin_openid")] public string? BeginOpenId { get; set; }
}

using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 转换 OpenId 请求（POST /cgi-bin/changeopenid）
/// </summary>
public class ChangeOpenIdRequest
{
    /// <summary>原账号原始 ID（gh_xxx，不是 AppId）</summary>
    [JsonPropertyName("from_appid")] public required string FromAppId { get; set; }

    /// <summary>旧账号 OpenId 列表（一次最多 100 个）</summary>
    [JsonPropertyName("openid_list")] public required List<string> OpenIdList { get; set; }
}

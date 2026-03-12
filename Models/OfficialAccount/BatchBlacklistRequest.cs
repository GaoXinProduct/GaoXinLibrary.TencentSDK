using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 拉黑/取消拉黑用户请求（POST /cgi-bin/tags/members/batchblacklist 或 /cgi-bin/tags/members/batchunblacklist）
/// </summary>
public class BatchBlacklistRequest
{
    /// <summary>要操作的 OpenId 列表（一次最多 20 个）</summary>
    [JsonPropertyName("openid_list")] public required List<string> OpenIdList { get; set; }
}

using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>获取标签下粉丝列表请求（POST /cgi-bin/user/tag/get）</summary>
public class GetTagUsersRequest
{
    [JsonPropertyName("tagid")] public required int TagId { get; set; }
    [JsonPropertyName("next_openid")] public string? NextOpenId { get; set; }
}


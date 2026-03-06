using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>获取标签下粉丝列表响应</summary>
public class GetTagUsersResponse : WechatBaseResponse
{
    [JsonPropertyName("count")] public int Count { get; set; }
    [JsonPropertyName("data")] public UserListData? Data { get; set; }
    [JsonPropertyName("next_openid")] public string? NextOpenId { get; set; }
}


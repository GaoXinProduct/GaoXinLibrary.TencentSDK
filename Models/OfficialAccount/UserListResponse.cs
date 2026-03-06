using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 获取用户列表响应（GET /cgi-bin/user/get）
/// </summary>
public class UserListResponse : WechatBaseResponse
{
    /// <summary>关注总数</summary>
    [JsonPropertyName("total")] public int Total { get; set; }

    /// <summary>拉取的 OpenId 个数</summary>
    [JsonPropertyName("count")] public int Count { get; set; }

    /// <summary>列表数据</summary>
    [JsonPropertyName("data")] public UserListData? Data { get; set; }

    /// <summary>拉取列表的最后一个用户 OpenId</summary>
    [JsonPropertyName("next_openid")] public string? NextOpenId { get; set; }
}


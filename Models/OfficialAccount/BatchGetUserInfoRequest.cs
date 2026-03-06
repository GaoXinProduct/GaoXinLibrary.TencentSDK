using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 批量获取用户信息请求（POST /cgi-bin/user/info/batchget）
/// </summary>
public class BatchGetUserInfoRequest
{
    /// <summary>用户列表</summary>
    [JsonPropertyName("user_list")] public required List<BatchGetUserItem> UserList { get; set; }
}


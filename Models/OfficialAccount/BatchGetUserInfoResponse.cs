using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 批量获取用户信息响应
/// </summary>
public class BatchGetUserInfoResponse : WechatBaseResponse
{
    /// <summary>用户信息列表</summary>
    [JsonPropertyName("user_info_list")] public List<UserInfoResponse>? UserInfoList { get; set; }
}


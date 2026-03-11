using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>获取配置了客户联系功能的成员列表响应</summary>
public class GetFollowUserListResponse : WecomBaseResponse
{
    /// <summary>配置了客户联系功能的成员userid列表</summary>
    [JsonPropertyName("follow_user")] public string[]? FollowUserList { get; set; }
}

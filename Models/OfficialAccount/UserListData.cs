using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>用户列表数据</summary>
public class UserListData
{
    /// <summary>OpenId 列表</summary>
    [JsonPropertyName("openid")] public List<string>? OpenId { get; set; }
}


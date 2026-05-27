using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>获取图文统计数据响应（POST /datacube/getuserread）</summary>
public sealed class UserReadResponse : WechatBaseResponse
{
    [JsonPropertyName("list")] public List<UserReadItem>? List { get; set; }
}


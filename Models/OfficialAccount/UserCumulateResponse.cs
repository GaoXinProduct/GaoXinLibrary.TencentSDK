using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>获取累计用户数据响应（POST /datacube/getusercumulate）</summary>
public sealed class UserCumulateResponse : WechatBaseResponse
{
    [JsonPropertyName("list")] public List<UserCumulateItem>? List { get; set; }
}


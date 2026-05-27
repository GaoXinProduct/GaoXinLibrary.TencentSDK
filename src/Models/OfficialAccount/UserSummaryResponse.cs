using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>获取用户增减数据响应（POST /datacube/getusersummary）</summary>
public sealed class UserSummaryResponse : WechatBaseResponse
{
    [JsonPropertyName("list")] public List<UserSummaryItem>? List { get; set; }
}


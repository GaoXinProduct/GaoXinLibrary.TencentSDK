using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>获取图文分享转发数据响应（POST /datacube/getusershare）</summary>
public class UserShareResponse : WechatBaseResponse
{
    [JsonPropertyName("list")] public List<UserShareItem>? List { get; set; }
}


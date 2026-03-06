using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>查询 rid 信息响应</summary>
public class OfficialGetRidInfoResponse : WechatBaseResponse
{
    [JsonPropertyName("request")] public OfficialRidRequestInfo? Request { get; set; }
}


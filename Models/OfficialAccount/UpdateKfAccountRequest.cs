using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>修改客服帐号请求（POST /customservice/kfaccount/update）</summary>
public class UpdateKfAccountRequest
{
    [JsonPropertyName("kf_account")] public required string KfAccount { get; set; }
    [JsonPropertyName("nickname")] public required string Nickname { get; set; }
}


using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>添加客服帐号请求（POST /customservice/kfaccount/add）</summary>
public class AddKfAccountRequest
{
    [JsonPropertyName("kf_account")] public required string KfAccount { get; set; }
    [JsonPropertyName("nickname")] public required string Nickname { get; set; }
}


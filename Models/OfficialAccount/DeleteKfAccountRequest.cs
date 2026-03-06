using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>删除客服帐号请求（POST /customservice/kfaccount/del）</summary>
public class DeleteKfAccountRequest
{
    [JsonPropertyName("kf_account")] public required string KfAccount { get; set; }
}


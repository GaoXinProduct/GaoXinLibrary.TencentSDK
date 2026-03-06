using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>指定客服账号</summary>
public class CustomServiceAccount
{
    [JsonPropertyName("kf_account")] public required string KfAccount { get; set; }
}


using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>客服帐号信息</summary>
public class KfAccountInfo
{
    [JsonPropertyName("kf_account")] public string? KfAccount { get; set; }
    [JsonPropertyName("kf_nick")] public string? KfNick { get; set; }
    [JsonPropertyName("kf_id")] public int KfId { get; set; }
}


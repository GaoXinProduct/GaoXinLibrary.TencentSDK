using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>累计用户数据项</summary>
public class UserCumulateItem
{
    [JsonPropertyName("ref_date")] public string? RefDate { get; set; }
    [JsonPropertyName("cumulate_user")] public int CumulateUser { get; set; }
}


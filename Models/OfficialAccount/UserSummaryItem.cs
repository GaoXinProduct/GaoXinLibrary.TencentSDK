using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>用户增减数据项</summary>
public class UserSummaryItem
{
    [JsonPropertyName("ref_date")] public string? RefDate { get; set; }
    [JsonPropertyName("user_source")] public int UserSource { get; set; }
    [JsonPropertyName("new_user")] public int NewUser { get; set; }
    [JsonPropertyName("cancel_user")] public int CancelUser { get; set; }
}


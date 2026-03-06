using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>图文分享转发数据项</summary>
public class UserShareItem
{
    [JsonPropertyName("ref_date")] public string? RefDate { get; set; }
    [JsonPropertyName("share_scene")] public int ShareScene { get; set; }
    [JsonPropertyName("share_user")] public int ShareUser { get; set; }
    [JsonPropertyName("share_count")] public int ShareCount { get; set; }
}


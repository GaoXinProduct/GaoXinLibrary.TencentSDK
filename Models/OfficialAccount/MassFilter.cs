using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>群发筛选</summary>
public class MassFilter
{
    [JsonPropertyName("is_to_all")] public bool IsToAll { get; set; }
    [JsonPropertyName("tag_id")] public int TagId { get; set; }
}


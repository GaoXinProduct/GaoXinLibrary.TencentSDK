using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>图文群发总数据详情</summary>
public class ArticleTotalDetail
{
    [JsonPropertyName("stat_date")] public string? StatDate { get; set; }
    [JsonPropertyName("target_user")] public int TargetUser { get; set; }
    [JsonPropertyName("int_page_read_user")] public int IntPageReadUser { get; set; }
    [JsonPropertyName("int_page_read_count")] public int IntPageReadCount { get; set; }
    [JsonPropertyName("ori_page_read_user")] public int OriPageReadUser { get; set; }
    [JsonPropertyName("ori_page_read_count")] public int OriPageReadCount { get; set; }
    [JsonPropertyName("share_user")] public int ShareUser { get; set; }
    [JsonPropertyName("share_count")] public int ShareCount { get; set; }
    [JsonPropertyName("add_to_fav_user")] public int AddToFavUser { get; set; }
    [JsonPropertyName("add_to_fav_count")] public int AddToFavCount { get; set; }
}


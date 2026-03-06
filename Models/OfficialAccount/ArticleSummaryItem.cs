using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>图文群发每日数据项</summary>
public class ArticleSummaryItem
{
    [JsonPropertyName("ref_date")] public string? RefDate { get; set; }
    [JsonPropertyName("msgid")] public string? MsgId { get; set; }
    [JsonPropertyName("title")] public string? Title { get; set; }
    [JsonPropertyName("int_page_read_user")] public int IntPageReadUser { get; set; }
    [JsonPropertyName("int_page_read_count")] public int IntPageReadCount { get; set; }
    [JsonPropertyName("ori_page_read_user")] public int OriPageReadUser { get; set; }
    [JsonPropertyName("ori_page_read_count")] public int OriPageReadCount { get; set; }
    [JsonPropertyName("share_user")] public int ShareUser { get; set; }
    [JsonPropertyName("share_count")] public int ShareCount { get; set; }
    [JsonPropertyName("add_to_fav_user")] public int AddToFavUser { get; set; }
    [JsonPropertyName("add_to_fav_count")] public int AddToFavCount { get; set; }
}


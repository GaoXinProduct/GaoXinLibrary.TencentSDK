using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>门店基本信息</summary>
public class PoiBaseInfo
{
    [JsonPropertyName("sid")] public string? Sid { get; set; }
    [JsonPropertyName("business_name")] public required string BusinessName { get; set; }
    [JsonPropertyName("branch_name")] public string? BranchName { get; set; }
    [JsonPropertyName("province")] public required string Province { get; set; }
    [JsonPropertyName("city")] public required string City { get; set; }
    [JsonPropertyName("district")] public string? District { get; set; }
    [JsonPropertyName("address")] public required string Address { get; set; }
    [JsonPropertyName("telephone")] public required string Telephone { get; set; }
    [JsonPropertyName("categories")] public required List<string> Categories { get; set; }
    [JsonPropertyName("offset_type")] public int OffsetType { get; set; } = 1;
    [JsonPropertyName("longitude")] public double Longitude { get; set; }
    [JsonPropertyName("latitude")] public double Latitude { get; set; }
    [JsonPropertyName("photo_list")] public List<PoiPhoto>? PhotoList { get; set; }
    [JsonPropertyName("recommend")] public string? Recommend { get; set; }
    [JsonPropertyName("special")] public string? Special { get; set; }
    [JsonPropertyName("introduction")] public string? Introduction { get; set; }
    [JsonPropertyName("open_time")] public string? OpenTime { get; set; }
    [JsonPropertyName("avg_price")] public int AvgPrice { get; set; }
    [JsonPropertyName("poi_id")] public string? PoiId { get; set; }
    [JsonPropertyName("available_state")] public int AvailableState { get; set; }
    [JsonPropertyName("update_status")] public int UpdateStatus { get; set; }
}


using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>查询门店列表响应</summary>
public class GetPoiListResponse : WechatBaseResponse
{
    [JsonPropertyName("business_list")] public List<PoiBusiness>? BusinessList { get; set; }
    [JsonPropertyName("total_count")] public int TotalCount { get; set; }
}


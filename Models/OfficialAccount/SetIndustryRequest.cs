using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>设置所属行业请求（POST /cgi-bin/template/api_set_industry）</summary>
public class SetIndustryRequest
{
    [JsonPropertyName("industry_id1")] public required string IndustryId1 { get; set; }
    [JsonPropertyName("industry_id2")] public required string IndustryId2 { get; set; }
}


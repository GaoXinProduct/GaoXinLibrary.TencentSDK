using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>获取设置的行业信息响应（GET /cgi-bin/template/get_industry）</summary>
public class GetIndustryResponse : WechatBaseResponse
{
    [JsonPropertyName("primary_industry")] public IndustryInfo? PrimaryIndustry { get; set; }
    [JsonPropertyName("secondary_industry")] public IndustryInfo? SecondaryIndustry { get; set; }
}


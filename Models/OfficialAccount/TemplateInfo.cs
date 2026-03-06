using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>模板信息</summary>
public class TemplateInfo
{
    [JsonPropertyName("template_id")] public string? TemplateId { get; set; }
    [JsonPropertyName("title")] public string? Title { get; set; }
    [JsonPropertyName("primary_industry")] public string? PrimaryIndustry { get; set; }
    [JsonPropertyName("deputy_industry")] public string? DeputyIndustry { get; set; }
    [JsonPropertyName("content")] public string? Content { get; set; }
    [JsonPropertyName("example")] public string? Example { get; set; }
}


using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Agent;

/// <summary>设置应用请求</summary>
public class SetAgentRequest
{
    [JsonPropertyName("agentid")] public int AgentId { get; set; }
    [JsonPropertyName("report_location_flag")] public int? ReportLocationFlag { get; set; }
    [JsonPropertyName("logo_mediaid")] public string? LogoMediaId { get; set; }
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("description")] public string? Description { get; set; }
    [JsonPropertyName("redirect_domain")] public string? RedirectDomain { get; set; }
    [JsonPropertyName("isreportenter")] public int? IsReportEnter { get; set; }
    [JsonPropertyName("home_url")] public string? HomeUrl { get; set; }
}


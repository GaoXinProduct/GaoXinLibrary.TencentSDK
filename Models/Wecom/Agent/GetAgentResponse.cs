using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Agent;

public class GetAgentResponse : WecomBaseResponse
{
    [JsonPropertyName("agentid")] public int AgentId { get; set; }
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("description")] public string? Description { get; set; }
    [JsonPropertyName("allow_userinfos")] public AgentUserInfos? AllowUserInfos { get; set; }
    [JsonPropertyName("allow_partys")] public AgentPartyIds? AllowPartys { get; set; }
    [JsonPropertyName("allow_tags")] public AgentTagIds? AllowTags { get; set; }
    [JsonPropertyName("close")] public int Close { get; set; }
    [JsonPropertyName("redirect_domain")] public string? RedirectDomain { get; set; }
    [JsonPropertyName("report_location_flag")] public int ReportLocationFlag { get; set; }
    [JsonPropertyName("isreportenter")] public int IsReportEnter { get; set; }
    [JsonPropertyName("home_url")] public string? HomeUrl { get; set; }
    [JsonPropertyName("square_logo_url")] public string? SquareLogoUrl { get; set; }
    [JsonPropertyName("round_logo_url")] public string? RoundLogoUrl { get; set; }

    public AgentInfo ToAgentInfo() => new()
    {
        AgentId = AgentId,
        Name = Name,
        Description = Description,
        AllowUserInfos = AllowUserInfos,
        AllowPartys = AllowPartys,
        AllowTags = AllowTags,
        Close = Close,
        RedirectDomain = RedirectDomain,
        ReportLocationFlag = ReportLocationFlag,
        IsReportEnter = IsReportEnter,
        HomeUrl = HomeUrl,
        SquareLogoUrl = SquareLogoUrl,
        RoundLogoUrl = RoundLogoUrl
    };
}


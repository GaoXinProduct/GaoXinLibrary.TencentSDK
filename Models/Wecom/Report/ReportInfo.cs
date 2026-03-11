using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Report;

/// <summary>汇报信息</summary>
public class ReportInfo
{
    /// <summary>汇报单号</summary>
    [JsonPropertyName("sp_no")] public string? SpNo { get; set; }

    /// <summary>汇报者userid</summary>
    [JsonPropertyName("creator_userid")] public string? CreatorUserId { get; set; }

    /// <summary>创建时间</summary>
    [JsonPropertyName("create_time")] public long CreateTime { get; set; }

    /// <summary>汇报模板名称</summary>
    [JsonPropertyName("template_name")] public string? TemplateName { get; set; }
}

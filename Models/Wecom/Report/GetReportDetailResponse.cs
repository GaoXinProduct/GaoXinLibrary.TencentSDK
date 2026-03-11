using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Report;

/// <summary>获取汇报记录详情响应</summary>
public class GetReportDetailResponse : WecomBaseResponse
{
    /// <summary>汇报信息</summary>
    [JsonPropertyName("report_info")] public ReportInfo? ReportInfo { get; set; }
}

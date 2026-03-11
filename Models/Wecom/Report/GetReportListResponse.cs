using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Report;

/// <summary>批量获取汇报记录单号响应</summary>
public class GetReportListResponse : WecomBaseResponse
{
    /// <summary>汇报记录单号列表</summary>
    [JsonPropertyName("sp_no_list")] public string[]? SpNoList { get; set; }
}

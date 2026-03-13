using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Report;

/// <summary>获取汇报详情请求</summary>
public class GetReportDetailRequest
{
    /// <summary>汇报 UUID</summary>
    [JsonPropertyName("journaluuid")]
    public string JournalUuid { get; set; } = string.Empty;
}

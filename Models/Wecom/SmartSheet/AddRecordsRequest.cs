using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartSheet;

/// <summary>添加记录请求</summary>
public class AddRecordsRequest
{
    /// <summary>文档 ID</summary>
    [JsonPropertyName("docid")]
    public string DocId { get; set; } = string.Empty;

    /// <summary>子表 ID</summary>
    [JsonPropertyName("sheet_id")]
    public string SheetId { get; set; } = string.Empty;

    /// <summary>记录列表</summary>
    [JsonPropertyName("records")]
    public SheetRecord[] Records { get; set; } = [];
}

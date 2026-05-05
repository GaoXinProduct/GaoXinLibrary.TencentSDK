using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Document.Spreadsheet;

/// <summary>获取表格数据请求</summary>
public class GetSpreadsheetDataRequest
{
    /// <summary>文档 ID</summary>
    [JsonPropertyName("docid")]
    public string DocId { get; set; } = string.Empty;

    /// <summary>子表 ID</summary>
    [JsonPropertyName("sheet_id")]
    public string SheetId { get; set; } = string.Empty;

    /// <summary>数据范围（省略时获取全表）</summary>
    [JsonPropertyName("range")]
    public SpreadsheetRange? Range { get; set; }
}

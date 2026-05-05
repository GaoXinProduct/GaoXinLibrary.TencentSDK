using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Document.Spreadsheet;

/// <summary>编辑表格内容请求</summary>
public class EditSpreadsheetContentRequest
{
    /// <summary>文档 ID</summary>
    [JsonPropertyName("docid")]
    public string DocId { get; set; } = string.Empty;

    /// <summary>子表 ID</summary>
    [JsonPropertyName("sheet_id")]
    public string SheetId { get; set; } = string.Empty;

    /// <summary>数据范围</summary>
    [JsonPropertyName("range")]
    public SpreadsheetRange Range { get; set; } = new();

    /// <summary>数据（行列矩阵）</summary>
    [JsonPropertyName("values")]
    public string[][] Values { get; set; } = [];
}

/// <summary>表格数据范围</summary>
public class SpreadsheetRange
{
    /// <summary>起始行（0基）</summary>
    [JsonPropertyName("row_start")]
    public int RowStart { get; set; }

    /// <summary>起始列（0基）</summary>
    [JsonPropertyName("col_start")]
    public int ColStart { get; set; }

    /// <summary>结束行（0基）</summary>
    [JsonPropertyName("row_end")]
    public int RowEnd { get; set; }

    /// <summary>结束列（0基）</summary>
    [JsonPropertyName("col_end")]
    public int ColEnd { get; set; }
}

using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Document.Spreadsheet;

/// <summary>获取表格数据响应</summary>
public class GetSpreadsheetDataResponse : WecomBaseResponse
{
    /// <summary>数据（行列矩阵）</summary>
    [JsonPropertyName("values")] public string[][]? Values { get; set; }

    /// <summary>行数</summary>
    [JsonPropertyName("row_count")] public int RowCount { get; set; }

    /// <summary>列数</summary>
    [JsonPropertyName("col_count")] public int ColCount { get; set; }
}

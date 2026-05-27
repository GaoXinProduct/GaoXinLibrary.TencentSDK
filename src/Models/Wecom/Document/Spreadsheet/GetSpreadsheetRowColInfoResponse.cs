using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Document.Spreadsheet;

/// <summary>获取表格行列信息响应</summary>
public class GetSpreadsheetRowColInfoResponse : WecomBaseResponse
{
    /// <summary>行数</summary>
    [JsonPropertyName("row_count")] public int RowCount { get; set; }

    /// <summary>列数</summary>
    [JsonPropertyName("col_count")] public int ColCount { get; set; }
}

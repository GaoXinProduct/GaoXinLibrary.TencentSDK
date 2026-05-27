using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Document.Spreadsheet;

/// <summary>编辑表格内容响应</summary>
public class EditSpreadsheetContentResponse : WecomBaseResponse
{
    /// <summary>修改的单元格数</summary>
    [JsonPropertyName("modified")] public int Modified { get; set; }
}

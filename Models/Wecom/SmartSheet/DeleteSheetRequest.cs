using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartSheet;

/// <summary>删除子表请求</summary>
public class DeleteSheetRequest
{
    /// <summary>文档 ID</summary>
    [JsonPropertyName("docid")]
    public string DocId { get; set; } = string.Empty;

    /// <summary>子表 ID 列表</summary>
    [JsonPropertyName("sheet_ids")]
    public string[] SheetIds { get; set; } = [];
}

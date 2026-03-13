using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartSheet;

/// <summary>添加字段请求</summary>
public class AddFieldsRequest
{
    /// <summary>文档 ID</summary>
    [JsonPropertyName("docid")]
    public string DocId { get; set; } = string.Empty;

    /// <summary>子表 ID</summary>
    [JsonPropertyName("sheet_id")]
    public string SheetId { get; set; } = string.Empty;

    /// <summary>字段列表</summary>
    [JsonPropertyName("fields")]
    public SheetField[] Fields { get; set; } = [];
}

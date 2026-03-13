using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartSheet;

/// <summary>获取记录列表请求</summary>
public class GetRecordsRequest
{
    /// <summary>文档 ID</summary>
    [JsonPropertyName("docid")]
    public string DocId { get; set; } = string.Empty;

    /// <summary>子表 ID</summary>
    [JsonPropertyName("sheet_id")]
    public string SheetId { get; set; } = string.Empty;

    /// <summary>偏移量</summary>
    [JsonPropertyName("offset")]
    public int? Offset { get; set; }

    /// <summary>每页大小</summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

    /// <summary>字段 ID 列表</summary>
    [JsonPropertyName("field_ids")]
    public string[]? FieldIds { get; set; }

    /// <summary>视图 ID</summary>
    [JsonPropertyName("view_id")]
    public string? ViewId { get; set; }
}

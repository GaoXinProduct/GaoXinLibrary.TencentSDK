using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartTable;

/// <summary>添加记录请求</summary>
public record AddRecordRequest(
    [property:JsonPropertyName("docid")] string DocId,
    [property:JsonPropertyName("sheet_id")] string SheetId,
    [property:JsonPropertyName("records")] RecordData[] Records
);

/// <summary>记录数据</summary>
public class RecordData
{
    /// <summary>字段 ID 到值的映射</summary>
    [JsonPropertyName("values")] public Dictionary<string, object>? Values { get; set; }
}

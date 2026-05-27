using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartTable;

/// <summary>更新记录请求</summary>
public record UpdateRecordRequest(
    [property:JsonPropertyName("docid")] string DocId,
    [property:JsonPropertyName("sheet_id")] string SheetId,
    [property:JsonPropertyName("record_id")] string RecordId,
    [property:JsonPropertyName("values")] Dictionary<string, object> Values
);

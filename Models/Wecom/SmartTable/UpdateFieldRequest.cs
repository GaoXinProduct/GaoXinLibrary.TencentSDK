using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartTable;

/// <summary>更新字段请求</summary>
public record UpdateFieldRequest(
    [property:JsonPropertyName("docid")] string DocId,
    [property:JsonPropertyName("sheet_id")] string SheetId,
    [property:JsonPropertyName("field_id")] string FieldId,
    [property:JsonPropertyName("field_title")] string FieldTitle
);

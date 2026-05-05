using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartTable;

/// <summary>添加字段请求</summary>
public record AddFieldRequest(
    [property:JsonPropertyName("docid")] string DocId,
    [property:JsonPropertyName("sheet_id")] string SheetId,
    [property:JsonPropertyName("fields")] FieldProperty[] Fields
);

/// <summary>字段属性</summary>
public class FieldProperty
{
    /// <summary>字段标题</summary>
    [JsonPropertyName("field_title")] public string? FieldTitle { get; set; }

    /// <summary>字段类型</summary>
    [JsonPropertyName("field_type")] public string? FieldType { get; set; }
}

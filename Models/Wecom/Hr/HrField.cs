using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Hr;

/// <summary>花名册字段</summary>
public class HrField
{
    /// <summary>字段id</summary>
    [JsonPropertyName("fieldid")] public int FieldId { get; set; }

    /// <summary>字段名称</summary>
    [JsonPropertyName("field_name")] public string? FieldName { get; set; }

    /// <summary>字段类型</summary>
    [JsonPropertyName("field_type")] public int FieldType { get; set; }
}

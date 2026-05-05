using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartTable;

/// <summary>字段信息</summary>
public class FieldInfo
{
    /// <summary>字段 ID</summary>
    [JsonPropertyName("field_id")] public string? FieldId { get; set; }

    /// <summary>字段标题</summary>
    [JsonPropertyName("field_title")] public string? FieldTitle { get; set; }

    /// <summary>字段类型</summary>
    [JsonPropertyName("field_type")] public string? FieldType { get; set; }

    /// <summary>字段属性</summary>
    [JsonPropertyName("field_value")] public object? FieldValue { get; set; }
}

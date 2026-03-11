using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartSheet;

/// <summary>智能表格字段信息</summary>
public class SheetField
{
    /// <summary>字段ID</summary>
    [JsonPropertyName("field_id")] public string? FieldId { get; set; }

    /// <summary>字段标题</summary>
    [JsonPropertyName("field_title")] public string? FieldTitle { get; set; }

    /// <summary>字段类型：FIELD_TYPE_TEXT / FIELD_TYPE_NUMBER / FIELD_TYPE_DATE 等</summary>
    [JsonPropertyName("field_type")] public string? FieldType { get; set; }

    /// <summary>字段属性（不同类型字段对应不同属性结构）</summary>
    [JsonPropertyName("field_value")] public object? FieldValue { get; set; }
}

using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartTable;

/// <summary>子表信息</summary>
public class SubTableInfo
{
    /// <summary>子表 ID</summary>
    [JsonPropertyName("sheet_id")] public string? SheetId { get; set; }

    /// <summary>子表标题</summary>
    [JsonPropertyName("title")] public string? Title { get; set; }

    /// <summary>是否为默认子表</summary>
    [JsonPropertyName("is_default")] public bool? IsDefault { get; set; }

    /// <summary>字段数</summary>
    [JsonPropertyName("field_count")] public int FieldCount { get; set; }

    /// <summary>记录数</summary>
    [JsonPropertyName("record_count")] public int RecordCount { get; set; }
}

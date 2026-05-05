using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartTable;

/// <summary>添加编组请求</summary>
public record AddGroupRequest(
    [property:JsonPropertyName("docid")] string DocId,
    [property:JsonPropertyName("sheet_id")] string SheetId,
    [property:JsonPropertyName("group_name")] string GroupName,
    [property:JsonPropertyName("field_id")] string FieldId,
    [property:JsonPropertyName("group_type")] string GroupType
);

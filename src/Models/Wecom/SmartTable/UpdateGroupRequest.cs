using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartTable;

/// <summary>更新编组请求</summary>
public record UpdateGroupRequest(
    [property:JsonPropertyName("docid")] string DocId,
    [property:JsonPropertyName("sheet_id")] string SheetId,
    [property:JsonPropertyName("group_id")] string GroupId,
    [property:JsonPropertyName("group_name")] string GroupName
);

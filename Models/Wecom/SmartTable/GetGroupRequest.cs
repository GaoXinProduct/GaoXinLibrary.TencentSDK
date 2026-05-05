using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartTable;

/// <summary>查询编组请求</summary>
public record GetGroupRequest(
    [property:JsonPropertyName("docid")] string DocId,
    [property:JsonPropertyName("sheet_id")] string SheetId
);

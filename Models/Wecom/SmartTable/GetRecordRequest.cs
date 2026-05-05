using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartTable;

/// <summary>查询记录请求</summary>
public record GetRecordRequest(
    [property:JsonPropertyName("docid")] string DocId,
    [property:JsonPropertyName("sheet_id")] string SheetId,
    [property:JsonPropertyName("cursor")] string Cursor = "",
    [property:JsonPropertyName("limit")] int Limit = 100
);

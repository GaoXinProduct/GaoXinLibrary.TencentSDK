using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartTable;

/// <summary>更新视图请求</summary>
public record UpdateViewRequest(
    [property:JsonPropertyName("docid")] string DocId,
    [property:JsonPropertyName("sheet_id")] string SheetId,
    [property:JsonPropertyName("view_id")] string ViewId,
    [property:JsonPropertyName("title")] string Title
);

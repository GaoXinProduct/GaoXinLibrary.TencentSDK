
namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartSheet;

/// <summary>获取视图列表请求</summary>
public sealed class GetViewsRequest
{
    /// <summary>文档 ID</summary>
    [JsonPropertyName("docid")]
    public string DocId { get; set; } = string.Empty;

    /// <summary>子表 ID</summary>
    [JsonPropertyName("sheet_id")]
    public string SheetId { get; set; } = string.Empty;
}

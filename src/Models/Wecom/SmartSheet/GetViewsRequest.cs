
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

    /// <summary>指定要查询的视图 ID。省略时查询子表的全部视图。</summary>
    [JsonPropertyName("view_ids")]
    public string[]? ViewIds { get; set; }

    /// <summary>查询偏移量，从 0 开始。</summary>
    [JsonPropertyName("offset")]
    public uint? Offset { get; set; }

    /// <summary>每页数量，最大 1000。省略或传 0 时使用服务端默认值。</summary>
    [JsonPropertyName("limit")]
    public uint? Limit { get; set; }
}

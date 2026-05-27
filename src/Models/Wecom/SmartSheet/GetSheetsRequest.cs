
namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartSheet;

/// <summary>获取子表列表请求</summary>
public sealed class GetSheetsRequest
{
    /// <summary>文档 ID</summary>
    [JsonPropertyName("docid")]
    public string DocId { get; set; } = string.Empty;
}

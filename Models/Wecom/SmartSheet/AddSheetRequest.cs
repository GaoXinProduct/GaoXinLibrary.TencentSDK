using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartSheet;

/// <summary>添加子表请求</summary>
public class AddSheetRequest
{
    /// <summary>文档 ID</summary>
    [JsonPropertyName("docid")]
    public string DocId { get; set; } = string.Empty;

    /// <summary>子表属性列表</summary>
    [JsonPropertyName("properties")]
    public SheetInfo[] Properties { get; set; } = [];
}

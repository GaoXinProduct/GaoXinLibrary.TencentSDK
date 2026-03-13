using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartSheet;

/// <summary>修改子表属性请求</summary>
public class UpdateSheetRequest
{
    /// <summary>文档 ID</summary>
    [JsonPropertyName("docid")]
    public string DocId { get; set; } = string.Empty;

    /// <summary>子表属性列表</summary>
    [JsonPropertyName("properties")]
    public UpdateSheetProperty[] Properties { get; set; } = [];
}

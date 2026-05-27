using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartTable;

/// <summary>添加子表请求</summary>
public record AddSubTableRequest(
    [property:JsonPropertyName("docid")] string DocId,
    [property:JsonPropertyName("properties")] SubTableProperty[] Properties
);

/// <summary>子表属性</summary>
public class SubTableProperty
{
    /// <summary>子表标题</summary>
    [JsonPropertyName("title")] public string? Title { get; set; }
}

using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CollectForm;

/// <summary>编辑收集表请求</summary>
public class EditCollectFormRequest
{
    /// <summary>收集表 ID</summary>
    [JsonPropertyName("formid")]
    public string FormId { get; set; } = string.Empty;

    /// <summary>收集表标题</summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <summary>收集表描述</summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>截止时间（Unix时间戳，0表示不限制）</summary>
    [JsonPropertyName("end_time")]
    public long EndTime { get; set; }
}

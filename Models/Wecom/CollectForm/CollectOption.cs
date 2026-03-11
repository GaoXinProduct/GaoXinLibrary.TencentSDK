using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.CollectForm;

/// <summary>收集表选项</summary>
public class CollectOption
{
    /// <summary>选项ID</summary>
    [JsonPropertyName("option_id")] public int OptionId { get; set; }

    /// <summary>选项文本</summary>
    [JsonPropertyName("text")] public string? Text { get; set; }
}

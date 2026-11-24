
namespace GaoXinLibrary.TencentSDK.Wecom.Models.CollectForm;

/// <summary>收集表选项</summary>
public sealed class CollectOption
{
    /// <summary>选项ID</summary>
    [JsonPropertyName("key")] public int OptionId { get; set; }

    /// <summary>选项文本</summary>
    [JsonPropertyName("value")] public string? Text { get; set; }

    /// <summary>选项状态，1 为正常，2 为已删除。</summary>
    [JsonPropertyName("status")] public int Status { get; set; } = 1;
}

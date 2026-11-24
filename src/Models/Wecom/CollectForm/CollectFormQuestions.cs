namespace GaoXinLibrary.TencentSDK.Wecom.Models.CollectForm;

/// <summary>收集表问题列表。</summary>
public sealed class CollectFormQuestions
{
    /// <summary>问题数组。</summary>
    [JsonPropertyName("items")] public CollectQuestion[] Items { get; set; } = [];
}

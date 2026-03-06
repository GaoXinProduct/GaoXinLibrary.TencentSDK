using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Message;

/// <summary>更多操作按钮中的操作项</summary>
public class TemplateCardActionItem
{
    /// <summary>操作的描述文案</summary>
    [JsonPropertyName("text")] public string Text { get; set; } = string.Empty;

    /// <summary>操作 key 值（点击后回调用）</summary>
    [JsonPropertyName("key")] public string Key { get; set; } = string.Empty;
}


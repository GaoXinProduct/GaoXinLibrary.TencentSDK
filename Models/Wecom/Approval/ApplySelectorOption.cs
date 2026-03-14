using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

/// <summary>选择器选中项</summary>
public class ApplySelectorOption
{
    /// <summary>选项 key</summary>
    [JsonPropertyName("key")] public string? Key { get; set; }

    /// <summary>选项值（多语言文本，假期类型选项等场景使用）</summary>
    [JsonPropertyName("value")] public ApprovalText[]? Value { get; set; }
}


using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

/// <summary>选择器控件配置</summary>
public class SelectorConfig
{
    /// <summary>选择器类型：single / multi</summary>
    [JsonPropertyName("type")] public string? Type { get; set; }

    /// <summary>选项列表</summary>
    [JsonPropertyName("options")] public SelectorOption[]? Options { get; set; }
}


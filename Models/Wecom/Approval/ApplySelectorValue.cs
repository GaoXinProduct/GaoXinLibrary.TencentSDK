using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

/// <summary>选择器值</summary>
public class ApplySelectorValue
{
    /// <summary>选择器类型：single / multi</summary>
    [JsonPropertyName("type")] public string? Type { get; set; }

    /// <summary>选中的选项列表</summary>
    [JsonPropertyName("options")] public ApplySelectorOption[]? Options { get; set; }

    /// <summary>选项展示类型（假勤组件使用）</summary>
    [JsonPropertyName("exp_type")] public int? ExpType { get; set; }
}


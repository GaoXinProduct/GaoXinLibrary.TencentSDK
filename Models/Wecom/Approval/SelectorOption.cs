using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

/// <summary>选择器选项</summary>
public class SelectorOption
{
    /// <summary>选项 key</summary>
    [JsonPropertyName("key")] public string? Key { get; set; }

    /// <summary>选项值</summary>
    [JsonPropertyName("value")] public ApprovalText[]? Value { get; set; }
}


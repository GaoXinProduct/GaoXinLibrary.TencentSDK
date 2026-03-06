using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

/// <summary>审批申请内容</summary>
public class ApplyContent
{
    /// <summary>控件类型</summary>
    [JsonPropertyName("control")] public string Control { get; set; } = string.Empty;

    /// <summary>控件 id</summary>
    [JsonPropertyName("id")] public string Id { get; set; } = string.Empty;

    /// <summary>控件值</summary>
    [JsonPropertyName("value")] public ApplyContentValue? Value { get; set; }
}


using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.LinkedCorp;

/// <summary>文本属性值</summary>
public class LinkedCorpAttrText
{
    /// <summary>文本值</summary>
    [JsonPropertyName("value")] public string? Value { get; set; }
}


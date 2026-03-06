using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.LinkedCorp;

/// <summary>单个扩展属性</summary>
public class LinkedCorpAttr
{
    /// <summary>属性名称</summary>
    [JsonPropertyName("name")] public string? Name { get; set; }

    /// <summary>属性类型: 0-文本 1-网页</summary>
    [JsonPropertyName("type")] public int Type { get; set; }

    /// <summary>文本类型的属性值</summary>
    [JsonPropertyName("text")] public LinkedCorpAttrText? Text { get; set; }

    /// <summary>网页类型的属性值</summary>
    [JsonPropertyName("web")] public LinkedCorpAttrWeb? Web { get; set; }
}


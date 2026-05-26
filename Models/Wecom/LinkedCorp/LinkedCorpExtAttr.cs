using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.LinkedCorp;

/// <summary>扩展属性</summary>
public sealed class LinkedCorpExtAttr
{
    /// <summary>属性列表</summary>
    [JsonPropertyName("attrs")] public LinkedCorpAttr[]? Attrs { get; set; }
}


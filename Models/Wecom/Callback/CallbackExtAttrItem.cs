using System.Xml.Linq;
using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Callback;

/// <summary>通讯录回调扩展属性项</summary>
public class CallbackExtAttrItem
{
    /// <summary>属性名称</summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>属性类型（0-文本 1-网页）</summary>
    public int Type { get; set; }

    /// <summary>文本属性值（Type=0 时有效）</summary>
    public string? Value { get; set; }

    /// <summary>网页属性 URL（Type=1 时有效）</summary>
    public string? WebUrl { get; set; }

    /// <summary>网页属性标题（Type=1 时有效）</summary>
    public string? WebTitle { get; set; }
}


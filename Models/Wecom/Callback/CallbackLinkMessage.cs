using System.Xml.Linq;
using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Callback;

/// <summary>链接消息</summary>
public class CallbackLinkMessage : CallbackMessageBase
{
    /// <summary>消息 ID</summary>
    public long MsgId { get; set; }

    /// <summary>标题</summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>描述</summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>链接跳转 URL</summary>
    public string Url { get; set; } = string.Empty;

    /// <summary>封面缩略图的 URL</summary>
    public string? PicUrl { get; set; }
}


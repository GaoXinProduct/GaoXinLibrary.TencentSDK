using System.Xml.Linq;
using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Callback;

/// <summary>被动回复图文消息中的文章项</summary>
public class CallbackReplyNewsArticle
{
    /// <summary>图文消息标题</summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>图文消息描述</summary>
    public string? Description { get; set; }

    /// <summary>图片链接（支持 JPG/PNG，较好效果为大图 640x320，小图 80x80）</summary>
    public string? PicUrl { get; set; }

    /// <summary>点击图文消息跳转链接</summary>
    public string? Url { get; set; }
}


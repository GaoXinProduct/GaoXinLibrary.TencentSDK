using System.Xml.Linq;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>图文回复消息中的文章项</summary>
public class OfficialCallbackReplyNewsArticle
{
    /// <summary>图文消息标题</summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>图文消息描述</summary>
    public string? Description { get; set; }

    /// <summary>图片链接（支持 JPG / PNG，大图 360x200，小图 200x200）</summary>
    public string? PicUrl { get; set; }

    /// <summary>点击图文消息跳转链接</summary>
    public string? Url { get; set; }
}


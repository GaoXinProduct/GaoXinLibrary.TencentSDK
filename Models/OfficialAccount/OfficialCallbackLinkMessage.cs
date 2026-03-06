using System.Xml.Linq;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>链接消息</summary>
public class OfficialCallbackLinkMessage : OfficialCallbackMessageBase
{
    /// <summary>消息 ID</summary>
    public long MsgId { get; set; }

    /// <summary>消息标题</summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>消息描述</summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>消息链接</summary>
    public string Url { get; set; } = string.Empty;

    /// <summary>消息的数据ID</summary>
    public string? MsgDataId { get; set; }

    /// <summary>多图文时第几篇文章，从1开始</summary>
    public string? Idx { get; set; }
}


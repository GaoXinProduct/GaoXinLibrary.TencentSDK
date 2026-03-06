using System.Xml.Linq;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>文本消息</summary>
public class OfficialCallbackTextMessage : OfficialCallbackMessageBase
{
    /// <summary>消息 ID（64位整型）</summary>
    public long MsgId { get; set; }

    /// <summary>文本消息内容</summary>
    public string Content { get; set; } = string.Empty;

    /// <summary>消息的数据ID（消息如果来自文章时才有）</summary>
    public string? MsgDataId { get; set; }

    /// <summary>多图文时第几篇文章，从1开始</summary>
    public string? Idx { get; set; }
}


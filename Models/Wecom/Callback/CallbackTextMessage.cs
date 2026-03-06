using System.Xml.Linq;
using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Callback;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>文本消息</summary>
public class CallbackTextMessage : CallbackMessageBase
{
    /// <summary>消息 ID（64位整型）</summary>
    public long MsgId { get; set; }

    /// <summary>文本消息内容</summary>
    public string Content { get; set; } = string.Empty;
}


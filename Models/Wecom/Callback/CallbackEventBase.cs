using System.Xml.Linq;
using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Callback;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>事件消息基类</summary>
public class CallbackEventBase : CallbackMessageBase
{
    /// <summary>事件类型（subscribe / unsubscribe / enter_agent / location / click / view / template_card_event 等）</summary>
    public string Event { get; set; } = string.Empty;
}


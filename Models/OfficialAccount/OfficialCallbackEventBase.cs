using System.Xml.Linq;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>事件消息基类</summary>
public class OfficialCallbackEventBase : OfficialCallbackMessageBase
{
    /// <summary>事件类型（subscribe / unsubscribe / SCAN / LOCATION / CLICK / VIEW 等）</summary>
    public string Event { get; set; } = string.Empty;
}


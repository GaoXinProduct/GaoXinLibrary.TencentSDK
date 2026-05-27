using System.Xml.Linq;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Callback;

/// <summary>点击菜单跳转链接事件</summary>
public sealed class CallbackViewEvent : CallbackEventBase
{
    /// <summary>事件 KEY 值（设置的跳转 URL）</summary>
    public string EventKey { get; set; } = string.Empty;
}


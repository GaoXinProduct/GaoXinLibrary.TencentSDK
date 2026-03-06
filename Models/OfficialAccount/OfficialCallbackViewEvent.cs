using System.Xml.Linq;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 点击菜单跳转链接事件
/// <para>Event = VIEW</para>
/// </summary>
public class OfficialCallbackViewEvent : OfficialCallbackEventBase
{
    /// <summary>事件 KEY 值（设置的跳转 URL）</summary>
    public string EventKey { get; set; } = string.Empty;

    /// <summary>菜单 ID（指菜单接口中的 MenuID）</summary>
    public string? MenuId { get; set; }
}


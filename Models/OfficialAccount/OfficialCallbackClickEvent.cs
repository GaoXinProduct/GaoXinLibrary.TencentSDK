using System.Xml.Linq;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 自定义菜单点击事件
/// <para>Event = CLICK</para>
/// </summary>
public class OfficialCallbackClickEvent : OfficialCallbackEventBase
{
    /// <summary>事件 KEY 值（与自定义菜单接口中 KEY 值对应）</summary>
    public string EventKey { get; set; } = string.Empty;
}


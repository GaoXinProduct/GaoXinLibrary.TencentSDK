using System.Xml.Linq;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 扫描带参数二维码事件（用户已关注时）
/// <para>Event = SCAN</para>
/// </summary>
public class OfficialCallbackScanEvent : OfficialCallbackEventBase
{
    /// <summary>事件 KEY（二维码的参数值）</summary>
    public string EventKey { get; set; } = string.Empty;

    /// <summary>二维码的 ticket</summary>
    public string Ticket { get; set; } = string.Empty;
}


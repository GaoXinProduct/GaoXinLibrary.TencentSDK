using System.Xml.Linq;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 关注/取消关注事件
/// <para>
/// 用户关注时 Event = subscribe，取消关注时 Event = unsubscribe。<br/>
/// 若用户扫描带参数二维码关注，EventKey 和 Ticket 将有值。
/// </para>
/// </summary>
public class OfficialCallbackSubscribeEvent : OfficialCallbackEventBase
{
    /// <summary>事件 KEY（扫描带参数二维码关注时：qrscene_为前缀，后面为二维码的参数值）</summary>
    public string? EventKey { get; set; }

    /// <summary>二维码的 ticket（可用来换取二维码图片）</summary>
    public string? Ticket { get; set; }
}


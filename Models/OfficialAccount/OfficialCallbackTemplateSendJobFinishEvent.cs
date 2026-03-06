using System.Xml.Linq;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 模板消息发送结果事件
/// <para>Event = TEMPLATESENDJOBFINISH</para>
/// </summary>
public class OfficialCallbackTemplateSendJobFinishEvent : OfficialCallbackEventBase
{
    /// <summary>模板消息 ID</summary>
    public long MsgID { get; set; }

    /// <summary>发送状态（success / failed:user block / failed:system failed）</summary>
    public string Status { get; set; } = string.Empty;
}


using System.Xml.Linq;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 群发消息发送结果事件
/// <para>Event = MASSSENDJOBFINISH</para>
/// </summary>
public class OfficialCallbackMassSendJobFinishEvent : OfficialCallbackEventBase
{
    /// <summary>群发消息 ID</summary>
    public long MsgID { get; set; }

    /// <summary>群发结果（send success / send fail / err(num)）</summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>tag_id 下粉丝数 / openid_list 中的粉丝数</summary>
    public int TotalCount { get; set; }

    /// <summary>过滤后准备发送的粉丝数</summary>
    public int FilterCount { get; set; }

    /// <summary>发送成功的粉丝数</summary>
    public int SentCount { get; set; }

    /// <summary>发送失败的粉丝数</summary>
    public int ErrorCount { get; set; }
}


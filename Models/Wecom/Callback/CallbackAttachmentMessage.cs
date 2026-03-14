using System.Xml.Linq;
using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Callback;

/// <summary>
/// 附件消息（混合消息类型）
/// <para>智能机器人接收到的附件/混合消息</para>
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/100719"/></para>
/// </summary>
public class CallbackAttachmentMessage : CallbackMessageBase
{
    /// <summary>消息 ID</summary>
    public long MsgId { get; set; }

    /// <summary>回调 ID</summary>
    public string CallbackId { get; set; } = string.Empty;

    /// <summary>操作列表</summary>
    public CallbackAttachmentAction[] Actions { get; set; } = [];
}

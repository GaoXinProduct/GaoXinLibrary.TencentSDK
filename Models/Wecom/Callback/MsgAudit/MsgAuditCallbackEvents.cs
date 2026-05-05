namespace GaoXinLibrary.TencentSDK.Wecom.Models.Callback.MsgAudit;

/// <summary>
/// 会话存档回调事件基类
/// </summary>
public abstract class MsgAuditCallbackEventBase : CallbackEventBase { }

/// <summary>
/// 聊天内容存档回调事件
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/95039"/></para>
/// </summary>
public class MsgAuditEvent : MsgAuditCallbackEventBase
{
    /// <summary>消息 ID</summary>
    public string MsgId { get; set; } = string.Empty;

    /// <summary>操作类型（sign=签岗 offline=离线 回调）</summary>
    public string Action { get; set; } = string.Empty;

    /// <summary>消息类型</summary>
    public new string MsgType { get; set; } = string.Empty;

    /// <summary>发送方 UserID</summary>
    public new string FromUserName { get; set; } = string.Empty;

    /// <summary>接收方 UserID 列表</summary>
    public new string[]? ToUserName { get; set; }

    /// <summary>消息内容</summary>
    public string? Content { get; set; }

    /// <summary>消息时间</summary>
    public long MsgTime { get; set; }
}
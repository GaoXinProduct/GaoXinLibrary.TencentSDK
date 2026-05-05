namespace GaoXinLibrary.TencentSDK.Wecom.Models.Callback;

/// <summary>
/// 邮件回调事件基类
/// </summary>
public abstract class EmailCallbackEventBase : CallbackEventBase { }

/// <summary>
/// 邮件变更事件
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/100180"/></para>
/// </summary>
public class EmailChangeEvent : EmailCallbackEventBase
{
    /// <summary>变更类型</summary>
    public string ChangeType { get; set; } = string.Empty;

    /// <summary>邮件 ID</summary>
    public string EmailId { get; set; } = string.Empty;

    /// <summary>主题</summary>
    public string? Subject { get; set; }

    /// <summary>发件人</summary>
    public string? From { get; set; }

    /// <summary>收件人</summary>
    public string? To { get; set; }

    /// <summary>时间戳</summary>
    public long Timestamp { get; set; }
}
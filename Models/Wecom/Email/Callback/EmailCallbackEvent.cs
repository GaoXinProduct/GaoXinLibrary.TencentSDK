using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Models.Callback;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Email.Callback;

/// <summary>
/// 邮件回调通知事件
/// </summary>
/// <remarks>文档路径: /document/path/100180</remarks>
public class EmailCallbackEvent : CallbackEventBase
{
    /// <summary>
    /// 事件类型: new_email（新邮件）、email_read（邮件已读）、email_delete（邮件删除）
    /// </summary>
    [JsonPropertyName("event")]
    public new string Event { get; set; } = string.Empty;

    /// <summary>邮件主题</summary>
    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

    /// <summary>发件人</summary>
    [JsonPropertyName("from")]
    public string? From { get; set; }

    /// <summary>收件人列表</summary>
    [JsonPropertyName("to_list")]
    public string[]? ToList { get; set; }

    /// <summary>抄送人列表</summary>
    [JsonPropertyName("cc_list")]
    public string[]? CcList { get; set; }

    /// <summary>邮件ID</summary>
    [JsonPropertyName("mailid")]
    public string? MailId { get; set; }

    /// <summary>操作类型（仅email_read/email_delete时有效）</summary>
    [JsonPropertyName("operate_type")]
    public string? OperateType { get; set; }
}
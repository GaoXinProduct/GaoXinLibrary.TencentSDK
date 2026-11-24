namespace GaoXinLibrary.TencentSDK.Wecom.Models.Email;

/// <summary>发送普通邮件请求。</summary>
public sealed class SendMailRequest
{
    /// <summary>收件人邮箱地址。可与 <see cref="Recipients"/> 一起使用。</summary>
    [JsonIgnore] public EmailAddress[]? To { get; set; }
    /// <summary>抄送邮箱地址。可与 <see cref="CopyRecipients"/> 一起使用。</summary>
    [JsonIgnore] public EmailAddress[]? Cc { get; set; }
    /// <summary>密送邮箱地址。可与 <see cref="BlindCopyRecipients"/> 一起使用。</summary>
    [JsonIgnore] public EmailAddress[]? Bcc { get; set; }

    /// <summary>收件人邮箱或成员 userid。</summary>
    [JsonPropertyName("to")] public MailRecipients? Recipients { get; set; }
    /// <summary>抄送人邮箱或成员 userid。</summary>
    [JsonPropertyName("cc")] public MailRecipients? CopyRecipients { get; set; }
    /// <summary>密送人邮箱或成员 userid。</summary>
    [JsonPropertyName("bcc")] public MailRecipients? BlindCopyRecipients { get; set; }
    /// <summary>邮件主题。</summary>
    [JsonPropertyName("subject")] public string Subject { get; set; } = string.Empty;
    /// <summary>邮件正文。</summary>
    [JsonPropertyName("content")] public string Content { get; set; } = string.Empty;
    /// <summary>正文类型，html 或 text。默认为 html。</summary>
    [JsonPropertyName("content_type")] public string ContentType { get; set; } = "html";
    /// <summary>邮件附件。</summary>
    [JsonPropertyName("attachment_list")] public MailAttachment[]? Attachments { get; set; }
    /// <summary>是否启用第三方应用 ID 转译，0 表示否，1 表示是。</summary>
    [JsonPropertyName("enable_id_trans")] public uint? EnableIdTranslation { get; set; }

    /// <summary>旧版发件人字段。发件人使用当前应用邮箱。</summary>
    [Obsolete("企业微信使用当前应用邮箱作为发件人。")]
    [JsonIgnore] public string? Sender { get; set; }
}

/// <summary>普通邮件的收件人范围。</summary>
public sealed class MailRecipients
{
    /// <summary>邮箱地址。</summary>
    [JsonPropertyName("emails")] public string[]? Emails { get; set; }
    /// <summary>企业成员 userid。</summary>
    [JsonPropertyName("userids")] public string[]? UserIds { get; set; }
}

/// <summary>普通邮件的附件。</summary>
public sealed class MailAttachment
{
    /// <summary>文件名。</summary>
    [JsonPropertyName("file_name")] public string FileName { get; set; } = string.Empty;
    /// <summary>文件内容，提交时序列化为 Base64。</summary>
    [JsonPropertyName("content")] public byte[] Content { get; set; } = [];
}

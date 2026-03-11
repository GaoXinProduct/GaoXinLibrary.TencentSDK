using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Email;

/// <summary>发送邮件请求</summary>
public class SendMailRequest
{
    /// <summary>收件人列表</summary>
    [JsonPropertyName("to")] public EmailAddress[]? To { get; set; }

    /// <summary>抄送列表</summary>
    [JsonPropertyName("cc")] public EmailAddress[]? Cc { get; set; }

    /// <summary>密送列表</summary>
    [JsonPropertyName("bcc")] public EmailAddress[]? Bcc { get; set; }

    /// <summary>邮件主题</summary>
    [JsonPropertyName("subject")] public string Subject { get; set; } = string.Empty;

    /// <summary>邮件内容</summary>
    [JsonPropertyName("content")] public string Content { get; set; } = string.Empty;

    /// <summary>内容类型 html/text</summary>
    [JsonPropertyName("content_type")] public string ContentType { get; set; } = "html";

    /// <summary>发件人userid</summary>
    [JsonPropertyName("sender")] public string? Sender { get; set; }
}

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Email;

/// <summary>读取指定邮件。</summary>
public sealed class ReadMailRequest
{
    /// <summary>由邮件列表返回的 ID。</summary>
    [JsonPropertyName("mail_id")] public string MailId { get; set; } = string.Empty;
}

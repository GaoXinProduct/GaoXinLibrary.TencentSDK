using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Email;

/// <summary>发送邮件响应</summary>
public sealed class SendMailResponse : WecomBaseResponse
{
    /// <summary>邮件ID</summary>
    [JsonPropertyName("mail_id")] public string? MailId { get; set; }
}

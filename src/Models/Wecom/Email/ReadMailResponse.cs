using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Email;

/// <summary>应用收件箱中的邮件内容。</summary>
public sealed class ReadMailResponse : WecomBaseResponse
{
    /// <summary>接口返回的 EML 内容。</summary>
    [JsonPropertyName("mail_data")] public string? MailData { get; set; }
}

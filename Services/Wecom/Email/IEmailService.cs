using GaoXinLibrary.TencentSDK.Wecom.Models.Email;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>邮件服务接口</summary>
public interface IEmailService
{
    /// <summary>发送普通邮件</summary>
    Task<string?> SendMailAsync(SendMailRequest request, CancellationToken ct = default);

    /// <summary>获取邮件未读数</summary>
    Task<int> GetUnreadCountAsync(GetMailUnreadCountRequest request, CancellationToken ct = default);
}

using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Email;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>邮件服务实现</summary>
public class EmailService : IEmailService
{
    private readonly WecomHttpClient _http;

    public EmailService(WecomHttpClient http) => _http = http;

    public async Task<string?> SendMailAsync(SendMailRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<SendMailResponse>("/cgi-bin/exmail/app/compose_send", request, ct);
        return resp.MailId;
    }

    public async Task<int> GetUnreadCountAsync(GetMailUnreadCountRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetMailUnreadCountResponse>("/cgi-bin/exmail/app/get_unread_count", request, ct);
        return resp.UnreadCount;
    }
}

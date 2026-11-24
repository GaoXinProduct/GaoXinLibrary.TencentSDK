using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Email;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>邮件服务实现</summary>
public sealed class EmailService
{
    private readonly WecomHttpClient _http;

    public EmailService(WecomHttpClient http) => _http = http;

    /// <summary>使用当前应用邮箱发送普通邮件。</summary>
    /// <remarks>接口成功时只保证返回错误码和说明，邮件 ID 可能为空。</remarks>
    public async Task<string?> SendMailAsync(SendMailRequest request, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        var recipients = MergeRecipients(request.Recipients, request.To);
        if (recipients?.Emails is not { Length: > 0 } && recipients?.UserIds is not { Length: > 0 })
            throw new ArgumentException("至少需要一个收件邮箱或成员 userid。", nameof(request));

        var resp = await _http.PostAsync<SendMailResponse>("/cgi-bin/exmail/app/compose_send", new
        {
            to = recipients,
            cc = MergeRecipients(request.CopyRecipients, request.Cc),
            bcc = MergeRecipients(request.BlindCopyRecipients, request.Bcc),
            subject = request.Subject,
            content = request.Content,
            content_type = request.ContentType,
            attachment_list = request.Attachments,
            enable_id_trans = request.EnableIdTranslation
        }, ct).ConfigureAwait(false);
        return resp.MailId;
    }

    /// <summary>按时间范围分页查询应用收件箱的邮件 ID。</summary>
    /// <remarks><see href="https://developer.work.weixin.qq.com/document/path/97369"/></remarks>
    public Task<GetMailListResponse> GetMailListAsync(GetMailListRequest request, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        if (request.BeginTime > request.EndTime)
            throw new ArgumentException("开始时间不能晚于结束时间。", nameof(request));
        if (request.Limit > 1000)
            throw new ArgumentOutOfRangeException(nameof(request), request.Limit, "每页最多返回 1000 封邮件。");
        return _http.PostQueryAsync<GetMailListResponse>("/cgi-bin/exmail/app/get_mail_list", request, ct);
    }

    /// <summary>获取指定邮件的 EML 内容。</summary>
    /// <remarks><see href="https://developer.work.weixin.qq.com/document/path/97979"/></remarks>
    public Task<ReadMailResponse> ReadMailAsync(ReadMailRequest request, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        ArgumentException.ThrowIfNullOrWhiteSpace(request.MailId);
        return _http.PostQueryAsync<ReadMailResponse>("/cgi-bin/exmail/app/read_mail", request, ct);
    }

    /// <summary>获取邮件未读数</summary>
    public async Task<int> GetUnreadCountAsync(GetMailUnreadCountRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostQueryAsync<GetMailUnreadCountResponse>("/cgi-bin/exmail/mail/get_newcount", request, ct).ConfigureAwait(false);
        return resp.UnreadCount;
    }

    /// <summary>更新应用邮箱账号，旧地址保留为收信别名。</summary>
    /// <remarks><see href="https://developer.work.weixin.qq.com/document/path/97373"/></remarks>
    public Task<UpdateEmailAccountResponse> UpdateEmailAccountAsync(UpdateEmailAccountRequest request, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        ArgumentException.ThrowIfNullOrWhiteSpace(request.NewEmail);
        return _http.PostAsync<UpdateEmailAccountResponse>("/cgi-bin/exmail/app/update_email_alias", request, ct);
    }

    /// <summary>兼容入口，查询当前应用的主邮箱和别名。</summary>
    public Task<GetEmailAccountResponse> GetEmailAccountAsync(GetEmailAccountRequest request, CancellationToken ct = default)
        => GetEmailAliasesAsync(ct);

    /// <summary>查询当前应用的主邮箱和别名。</summary>
    /// <remarks><see href="https://developer.work.weixin.qq.com/document/path/97991"/></remarks>
    public Task<GetEmailAccountResponse> GetEmailAliasesAsync(CancellationToken ct = default)
        => _http.PostQueryAsync<GetEmailAccountResponse>("/cgi-bin/exmail/app/get_email_alias", null, ct);

    /// <summary>创建邮件群组</summary>
    public async Task<CreateMailGroupResponse> CreateMailGroupAsync(CreateMailGroupRequest request, CancellationToken ct = default)
    {
        return await _http.PostAsync<CreateMailGroupResponse>("/cgi-bin/exmail/app/add_mail_group", request, ct).ConfigureAwait(false);
    }

    /// <summary>更新邮件群组</summary>
    public async Task<UpdateMailGroupResponse> UpdateMailGroupAsync(UpdateMailGroupRequest request, CancellationToken ct = default)
    {
        return await _http.PostAsync<UpdateMailGroupResponse>("/cgi-bin/exmail/app/update_mail_group", request, ct).ConfigureAwait(false);
    }

    /// <summary>删除邮件群组</summary>
    public async Task<DeleteMailGroupResponse> DeleteMailGroupAsync(DeleteMailGroupRequest request, CancellationToken ct = default)
    {
        return await _http.PostAsync<DeleteMailGroupResponse>("/cgi-bin/exmail/app/del_mail_group", request, ct).ConfigureAwait(false);
    }

    /// <summary>获取邮件群组详情</summary>
    public async Task<GetMailGroupDetailResponse> GetMailGroupDetailAsync(GetMailGroupDetailRequest request, CancellationToken ct = default)
    {
        return await _http.PostAsync<GetMailGroupDetailResponse>("/cgi-bin/exmail/app/get_mail_group_detail", request, ct).ConfigureAwait(false);
    }

    /// <summary>模糊搜索邮件群组</summary>
    public async Task<SearchMailGroupResponse> SearchMailGroupAsync(SearchMailGroupRequest request, CancellationToken ct = default)
    {
        return await _http.PostAsync<SearchMailGroupResponse>("/cgi-bin/exmail/app/search_mail_group", request, ct).ConfigureAwait(false);
    }

    /// <summary>创建公共邮箱</summary>
    public async Task<CreatePublicMailboxResponse> CreatePublicMailboxAsync(CreatePublicMailboxRequest request, CancellationToken ct = default)
    {
        return await _http.PostAsync<CreatePublicMailboxResponse>("/cgi-bin/exmail/app/add_public_mailbox", request, ct).ConfigureAwait(false);
    }

    /// <summary>更新公共邮箱</summary>
    public async Task<UpdatePublicMailboxResponse> UpdatePublicMailboxAsync(UpdatePublicMailboxRequest request, CancellationToken ct = default)
    {
        return await _http.PostAsync<UpdatePublicMailboxResponse>("/cgi-bin/exmail/app/update_public_mailbox", request, ct).ConfigureAwait(false);
    }

    /// <summary>删除公共邮箱</summary>
    public async Task<DeletePublicMailboxResponse> DeletePublicMailboxAsync(DeletePublicMailboxRequest request, CancellationToken ct = default)
    {
        return await _http.PostAsync<DeletePublicMailboxResponse>("/cgi-bin/exmail/app/del_public_mailbox", request, ct).ConfigureAwait(false);
    }

    /// <summary>获取公共邮箱详情</summary>
    public async Task<GetPublicMailboxDetailResponse> GetPublicMailboxDetailAsync(GetPublicMailboxDetailRequest request, CancellationToken ct = default)
    {
        return await _http.PostAsync<GetPublicMailboxDetailResponse>("/cgi-bin/exmail/app/get_public_mailbox_detail", request, ct).ConfigureAwait(false);
    }

    /// <summary>模糊搜索公共邮箱</summary>
    public async Task<SearchPublicMailboxResponse> SearchPublicMailboxAsync(SearchPublicMailboxRequest request, CancellationToken ct = default)
    {
        return await _http.PostAsync<SearchPublicMailboxResponse>("/cgi-bin/exmail/app/search_public_mailbox", request, ct).ConfigureAwait(false);
    }

    /// <summary>获取客户端专用密码列表</summary>
    public async Task<GetClientSecretResponse> GetClientSecretListAsync(GetClientSecretRequest request, CancellationToken ct = default)
    {
        return await _http.PostAsync<GetClientSecretResponse>("/cgi-bin/exmail/app/get_client_secret_list", request, ct).ConfigureAwait(false);
    }

    /// <summary>删除客户端专用密码</summary>
    public async Task<DeleteClientSecretResponse> DeleteClientSecretAsync(DeleteClientSecretRequest request, CancellationToken ct = default)
    {
        return await _http.PostAsync<DeleteClientSecretResponse>("/cgi-bin/exmail/app/del_client_secret", request, ct).ConfigureAwait(false);
    }

    /// <summary>获取邮件未读数</summary>
    public async Task<GetEmailUnreadCountResponse> GetEmailUnreadCountAsync(GetEmailUnreadCountRequest request, CancellationToken ct = default)
    {
        return await _http.PostQueryAsync<GetEmailUnreadCountResponse>("/cgi-bin/exmail/mail/get_newcount", request, ct).ConfigureAwait(false);
    }

    /// <summary>更改用户功能属性</summary>
    public async Task<SetFunctionAttrResponse> SetFunctionAttrAsync(SetFunctionAttrRequest request, CancellationToken ct = default)
    {
        return await _http.PostAsync<SetFunctionAttrResponse>("/cgi-bin/exmail/app/set_function_attr", request, ct).ConfigureAwait(false);
    }

    /// <summary>获取用户功能属性</summary>
    public async Task<GetFunctionAttrResponse> GetFunctionAttrAsync(GetFunctionAttrRequest request, CancellationToken ct = default)
    {
        return await _http.PostAsync<GetFunctionAttrResponse>("/cgi-bin/exmail/app/get_function_attr", request, ct).ConfigureAwait(false);
    }

    private static MailRecipients? MergeRecipients(MailRecipients? recipients, EmailAddress[]? addresses)
    {
        if (addresses is not { Length: > 0 })
            return recipients;

        return new MailRecipients
        {
            Emails = (recipients?.Emails ?? []).Concat(addresses.Select(static address => address.Addr)).ToArray(),
            UserIds = recipients?.UserIds
        };
    }
}

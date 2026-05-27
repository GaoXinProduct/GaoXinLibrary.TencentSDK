using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Email;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>邮件服务实现</summary>
public sealed class EmailService
{
    private readonly WecomHttpClient _http;

    public EmailService(WecomHttpClient http) => _http = http;

    /// <summary>发送普通邮件</summary>
    public async Task<string?> SendMailAsync(SendMailRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<SendMailResponse>("/cgi-bin/exmail/app/compose_send", request, ct).ConfigureAwait(false);
        return resp.MailId;
    }

    /// <summary>获取邮件未读数</summary>
    public async Task<int> GetUnreadCountAsync(GetMailUnreadCountRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetMailUnreadCountResponse>("/cgi-bin/exmail/app/get_unread_count", request, ct).ConfigureAwait(false);
        return resp.UnreadCount;
    }

    /// <summary>更新应用邮箱账号</summary>
    public async Task<UpdateEmailAccountResponse> UpdateEmailAccountAsync(UpdateEmailAccountRequest request, CancellationToken ct = default)
    {
        return await _http.PostAsync<UpdateEmailAccountResponse>("/cgi-bin/exmail/app/update_email_account", request, ct).ConfigureAwait(false);
    }

    /// <summary>查询应用邮箱账号</summary>
    public async Task<GetEmailAccountResponse> GetEmailAccountAsync(GetEmailAccountRequest request, CancellationToken ct = default)
    {
        return await _http.PostAsync<GetEmailAccountResponse>("/cgi-bin/exmail/app/get_email_account", request, ct).ConfigureAwait(false);
    }

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
        return await _http.PostAsync<GetEmailUnreadCountResponse>("/cgi-bin/exmail/app/get_unread_count", request, ct).ConfigureAwait(false);
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
}
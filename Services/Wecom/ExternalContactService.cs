using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>客户联系服务实现</summary>
public sealed class ExternalContactService
{
    private readonly WecomHttpClient _http;

    public ExternalContactService(WecomHttpClient http) => _http = http;

    /// <summary>获取配置了客户联系功能的成员列表</summary>
    public async Task<string[]> GetFollowUserListAsync(CancellationToken ct = default)
    {
        var resp = await _http.GetAsync<GetFollowUserListResponse>("/cgi-bin/externalcontact/get_follow_user_list", ct: ct).ConfigureAwait(false);
        return resp.FollowUserList ?? [];
    }

    /// <summary>获取客户列表</summary>
    public async Task<string[]> GetExternalContactListAsync(string userId, CancellationToken ct = default)
    {
        var resp = await _http.GetAsync<GetExternalContactListResponse>("/cgi-bin/externalcontact/list",
            new() { ["userid"] = userId }, ct).ConfigureAwait(false);
        return resp.ExternalUserIdList ?? [];
    }

    /// <summary>获取客户详情</summary>
    public async Task<GetExternalContactResponse> GetExternalContactAsync(string externalUserId, string? cursor = null, CancellationToken ct = default)
    {
        var query = new Dictionary<string, string?> { ["external_userid"] = externalUserId };
        if (!string.IsNullOrEmpty(cursor)) query["cursor"] = cursor;
        return await _http.GetAsync<GetExternalContactResponse>("/cgi-bin/externalcontact/get", query, ct).ConfigureAwait(false);
    }

    /// <summary>批量获取客户详情</summary>
    public async Task<BatchGetExternalContactResponse> BatchGetExternalContactAsync(BatchGetByUserRequest request, CancellationToken ct = default)
        => await _http.PostAsync<BatchGetExternalContactResponse>("/cgi-bin/externalcontact/batch/get_by_user", request, ct).ConfigureAwait(false);

    /// <summary>修改客户备注信息</summary>
    public async Task UpdateRemarkAsync(UpdateRemarkRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/externalcontact/remark", request, ct).ConfigureAwait(false);

    /// <summary>获取客户群列表</summary>
    public async Task<GetGroupChatListResponse> GetGroupChatListAsync(GetGroupChatListRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetGroupChatListResponse>("/cgi-bin/externalcontact/groupchat/list", request, ct).ConfigureAwait(false);

    /// <summary>获取「联系客户统计」数据</summary>
    public async Task<GetUserBehaviorDataResponse> GetUserBehaviorDataAsync(GetUserBehaviorDataRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetUserBehaviorDataResponse>("/cgi-bin/externalcontact/get_user_behavior_data", request, ct).ConfigureAwait(false);

    /// <summary>发送新客户欢迎语</summary>
    public async Task SendWelcomeMsgAsync(SendWelcomeMsgRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/externalcontact/send_welcome_msg", request, ct).ConfigureAwait(false);

    #region 客户朋友圈

    /// <summary>创建发表朋友圈任务</summary>
    public async Task<AddMomentTaskResponse> AddMomentTaskAsync(AddMomentTaskRequest request, CancellationToken ct = default)
        => await _http.PostAsync<AddMomentTaskResponse>("/cgi-bin/externalcontact/add_moment_task", request, ct).ConfigureAwait(false);

    /// <summary>取消发表朋友圈任务</summary>
    public async Task CancelMomentTaskAsync(CancelMomentTaskRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/externalcontact/cancel_moment_task", request, ct).ConfigureAwait(false);

    /// <summary>获取朋友圈列表</summary>
    public async Task<GetMomentListResponse> GetMomentListAsync(GetMomentListRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetMomentListResponse>("/cgi-bin/externalcontact/get_moment_list", request, ct).ConfigureAwait(false);

    /// <summary>获取朋友圈任务详情</summary>
    public async Task<GetMomentTaskResponse> GetMomentTaskAsync(GetMomentTaskRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetMomentTaskResponse>("/cgi-bin/externalcontact/get_moment_task", request, ct).ConfigureAwait(false);

    /// <summary>获取朋友圈客户列表</summary>
    public async Task<GetMomentCustomerListResponse> GetMomentCustomerListAsync(GetMomentCustomerListRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetMomentCustomerListResponse>("/cgi-bin/externalcontact/get_moment_customer_list", request, ct).ConfigureAwait(false);

    /// <summary>获取朋友圈发送结果</summary>
    public async Task<GetMomentSendResultResponse> GetMomentSendResultAsync(GetMomentSendResultRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetMomentSendResultResponse>("/cgi-bin/externalcontact/get_moment_send_result", request, ct).ConfigureAwait(false);

    #endregion

    #region 获客助手

    /// <summary>创建获客链接</summary>
    public async Task<CreateAcquisitionLinkResponse> CreateAcquisitionLinkAsync(CreateAcquisitionLinkRequest request, CancellationToken ct = default)
        => await _http.PostAsync<CreateAcquisitionLinkResponse>("/cgi-bin/externalcontact/customer_acquisition/create_link", request, ct).ConfigureAwait(false);

    /// <summary>获取获客链接详情</summary>
    public async Task<GetAcquisitionLinkResponse> GetAcquisitionLinkAsync(GetAcquisitionLinkRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetAcquisitionLinkResponse>("/cgi-bin/externalcontact/customer_acquisition/get", request, ct).ConfigureAwait(false);

    /// <summary>获取获客链接列表</summary>
    public async Task<ListAcquisitionLinkResponse> ListAcquisitionLinksAsync(ListAcquisitionLinkRequest? request = null, CancellationToken ct = default)
        => await _http.PostAsync<ListAcquisitionLinkResponse>("/cgi-bin/externalcontact/customer_acquisition/list", request ?? new(), ct).ConfigureAwait(false);

    /// <summary>更新获客链接</summary>
    public async Task UpdateAcquisitionLinkAsync(UpdateAcquisitionLinkRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/externalcontact/customer_acquisition/update_link", request, ct).ConfigureAwait(false);

    /// <summary>删除获客链接</summary>
    public async Task DeleteAcquisitionLinkAsync(DeleteAcquisitionLinkRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/externalcontact/customer_acquisition/delete_link", request, ct).ConfigureAwait(false);

    /// <summary>获取获客链接添加的客户</summary>
    public async Task<GetAcquisitionCustomerResponse> GetAcquisitionCustomerAsync(GetAcquisitionCustomerRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetAcquisitionCustomerResponse>("/cgi-bin/externalcontact/customer_acquisition/customer", request, ct).ConfigureAwait(false);

    #endregion

    #region 商品图册

    /// <summary>添加商品图册</summary>
    public async Task<AddProductAlbumResponse> AddProductAlbumAsync(AddProductAlbumRequest request, CancellationToken ct = default)
        => await _http.PostAsync<AddProductAlbumResponse>("/cgi-bin/externalcontact/add_product_album", request, ct).ConfigureAwait(false);

    /// <summary>获取商品图册列表</summary>
    public async Task<GetProductAlbumListResponse> GetProductAlbumListAsync(GetProductAlbumListRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetProductAlbumListResponse>("/cgi-bin/externalcontact/product_album/list", request, ct).ConfigureAwait(false);

    /// <summary>获取商品图册详情</summary>
    public async Task<ProductAlbumInfo?> GetProductAlbumAsync(GetProductAlbumRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetProductAlbumResponse>("/cgi-bin/externalcontact/product_album/get", request, ct).ConfigureAwait(false);
        return resp.Product;
    }

    /// <summary>更新商品图册</summary>
    public async Task UpdateProductAlbumAsync(UpdateProductAlbumRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/externalcontact/product_album/update", request, ct).ConfigureAwait(false);

    /// <summary>删除商品图册</summary>
    public async Task DeleteProductAlbumAsync(DeleteProductAlbumRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/externalcontact/product_album/delete", request, ct).ConfigureAwait(false);

    #endregion

    #region 聊天敏感词

    /// <summary>创建聊天敏感词规则</summary>
    public async Task<AddInterceptRuleResponse> CreateWordRuleAsync(AddInterceptRuleRequest request, CancellationToken ct = default)
        => await _http.PostAsync<AddInterceptRuleResponse>("/cgi-bin/externalcontact/add_intercept_rule", request, ct).ConfigureAwait(false);

    /// <summary>获取敏感词规则列表</summary>
    public async Task<GetInterceptRuleListResponse> GetWordRuleListAsync(CancellationToken ct = default)
        => await _http.PostAsync<GetInterceptRuleListResponse>("/cgi-bin/externalcontact/get_intercept_rule_list", new { }, ct).ConfigureAwait(false);

    /// <summary>获取敏感词规则详情</summary>
    public async Task<GetWordRuleResponse> GetWordRuleAsync(GetWordRuleRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetWordRuleResponse>("/cgi-bin/externalcontact/get_intercept_rule", request, ct).ConfigureAwait(false);

    /// <summary>更新聊天敏感词规则</summary>
    public async Task UpdateWordRuleAsync(UpdateInterceptRuleRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/externalcontact/update_intercept_rule", request, ct).ConfigureAwait(false);

    /// <summary>删除聊天敏感词规则</summary>
    public async Task DeleteWordRuleAsync(DeleteInterceptRuleRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/externalcontact/del_intercept_rule", request, ct).ConfigureAwait(false);

    #endregion
}

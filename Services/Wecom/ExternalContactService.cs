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

    #region 在职/离职继承

    /// <summary>分配在职成员的客户</summary>
    public async Task<TransferCustomerResponse> TransferCustomerAsync(TransferCustomerRequest request, CancellationToken ct = default)
        => await _http.PostAsync<TransferCustomerResponse>("/cgi-bin/externalcontact/transfer_customer", request, ct).ConfigureAwait(false);

    /// <summary>查询客户接替状态</summary>
    public async Task<GetTransferCustomerResultResponse> GetTransferResultAsync(GetTransferCustomerResultRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetTransferCustomerResultResponse>("/cgi-bin/externalcontact/transfer_result", request, ct).ConfigureAwait(false);

    /// <summary>分配在职成员的客户群</summary>
    public async Task<TransferGroupChatResponse> TransferGroupChatAsync(TransferGroupChatRequest request, CancellationToken ct = default)
        => await _http.PostAsync<TransferGroupChatResponse>("/cgi-bin/externalcontact/groupchat/transfer", request, ct).ConfigureAwait(false);

    /// <summary>获取待分配的离职成员列表</summary>
    public async Task<GetUnassignedListResponse> GetUnassignedListAsync(GetUnassignedListRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetUnassignedListResponse>("/cgi-bin/externalcontact/get_unassigned_list", request, ct).ConfigureAwait(false);

    /// <summary>分配离职成员的客户</summary>
    public async Task<DemotionTransferCustomerResponse> ResignedTransferCustomerAsync(DemotionTransferCustomerRequest request, CancellationToken ct = default)
        => await _http.PostAsync<DemotionTransferCustomerResponse>("/cgi-bin/externalcontact/resigned/transfer_customer", request, ct).ConfigureAwait(false);

    /// <summary>查询离职客户接替状态</summary>
    public async Task<GetDemotionTransferResultResponse> GetResignedTransferResultAsync(GetDemotionTransferResultRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetDemotionTransferResultResponse>("/cgi-bin/externalcontact/resigned/transfer_result", request, ct).ConfigureAwait(false);

    #endregion

    #region 客户标签管理

    /// <summary>获取企业标签库</summary>
    public async Task<GetCorpTagListResponse> GetCorpTagListAsync(GetCorpTagListRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetCorpTagListResponse>("/cgi-bin/externalcontact/get_corp_tag_list", request, ct).ConfigureAwait(false);

    /// <summary>添加企业客户标签</summary>
    public async Task<AddCorpTagResponse> AddCorpTagAsync(AddCorpTagRequest request, CancellationToken ct = default)
        => await _http.PostAsync<AddCorpTagResponse>("/cgi-bin/externalcontact/add_corp_tag", request, ct).ConfigureAwait(false);

    /// <summary>编辑企业客户标签</summary>
    public async Task UpdateCorpTagAsync(UpdateCorpTagRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/externalcontact/edit_corp_tag", request, ct).ConfigureAwait(false);

    /// <summary>删除企业客户标签</summary>
    public async Task DeleteCorpTagAsync(DeleteCorpTagRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/externalcontact/del_corp_tag", request, ct).ConfigureAwait(false);

    /// <summary>编辑客户企业标签</summary>
    public async Task MarkTagAsync(MarkTagRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/externalcontact/mark_tag", request, ct).ConfigureAwait(false);

    #endregion

    #region 客户群管理

    /// <summary>获取客户群详情</summary>
    public async Task<GetGroupChatDetailResponse> GetGroupChatDetailAsync(GetGroupChatDetailRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetGroupChatDetailResponse>("/cgi-bin/externalcontact/groupchat/get", request, ct).ConfigureAwait(false);

    /// <summary>客户群opengid转换</summary>
    public async Task<ConvertOpengIdResponse> ConvertOpengIdToChatIdAsync(ConvertOpengIdRequest request, CancellationToken ct = default)
        => await _http.PostAsync<ConvertOpengIdResponse>("/cgi-bin/externalcontact/opengid_to_chatid", request, ct).ConfigureAwait(false);

    #endregion

    #region 「联系我」管理

    /// <summary>配置客户联系「联系我」方式</summary>
    public async Task<AddContactWayResponse> AddContactWayAsync(AddContactWayRequest request, CancellationToken ct = default)
        => await _http.PostAsync<AddContactWayResponse>("/cgi-bin/externalcontact/add_contact_way", request, ct).ConfigureAwait(false);

    /// <summary>获取「联系我」方式</summary>
    public async Task<GetContactWayResponse> GetContactWayAsync(GetContactWayRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetContactWayResponse>("/cgi-bin/externalcontact/get_contact_way", request, ct).ConfigureAwait(false);

    /// <summary>更新「联系我」方式</summary>
    public async Task UpdateContactWayAsync(UpdateContactWayRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/externalcontact/update_contact_way", request, ct).ConfigureAwait(false);

    /// <summary>删除「联系我」方式</summary>
    public async Task DelContactWayAsync(DelContactWayRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/externalcontact/del_contact_way", request, ct).ConfigureAwait(false);

    #endregion

    #region 加入群聊管理

    /// <summary>配置客户群进群方式</summary>
    public async Task<AddJoinWayResponse> AddJoinWayAsync(AddJoinWayRequest request, CancellationToken ct = default)
        => await _http.PostAsync<AddJoinWayResponse>("/cgi-bin/externalcontact/groupchat/add_join_way", request, ct).ConfigureAwait(false);

    /// <summary>获取进群方式</summary>
    public async Task<GetJoinWayResponse> GetJoinWayAsync(GetJoinWayRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetJoinWayResponse>("/cgi-bin/externalcontact/groupchat/get_join_way", request, ct).ConfigureAwait(false);

    /// <summary>更新进群方式</summary>
    public async Task UpdateJoinWayAsync(UpdateJoinWayRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/externalcontact/groupchat/update_join_way", request, ct).ConfigureAwait(false);

    /// <summary>删除进群方式</summary>
    public async Task DelJoinWayAsync(DelJoinWayRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/externalcontact/groupchat/del_join_way", request, ct).ConfigureAwait(false);

    #endregion

    #region 企业群发

    /// <summary>创建企业群发</summary>
    public async Task<AddMsgTemplateResponse> AddMsgTemplateAsync(AddMsgTemplateRequest request, CancellationToken ct = default)
        => await _http.PostAsync<AddMsgTemplateResponse>("/cgi-bin/externalcontact/add_msg_template", request, ct).ConfigureAwait(false);

    /// <summary>提醒成员群发</summary>
    public async Task RemindGroupMsgSendAsync(RemindGroupMsgSendRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/externalcontact/remind_groupmsg_send", request, ct).ConfigureAwait(false);

    /// <summary>停止企业群发</summary>
    public async Task CancelGroupMsgSendAsync(CancelGroupMsgSendRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/externalcontact/cancel_groupmsg_send", request, ct).ConfigureAwait(false);

    /// <summary>获取群发记录列表</summary>
    public async Task<GetGroupmsgListV2Response> GetGroupmsgListV2Async(GetGroupMsgListV2Request request, CancellationToken ct = default)
        => await _http.PostAsync<GetGroupmsgListV2Response>("/cgi-bin/externalcontact/get_groupmsg_list_v2", request, ct).ConfigureAwait(false);

    /// <summary>获取群发成员发送任务列表</summary>
    public async Task<GetGroupmsgTaskResponse> GetGroupmsgTaskAsync(GetGroupMsgTaskRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetGroupmsgTaskResponse>("/cgi-bin/externalcontact/get_groupmsg_task", request, ct).ConfigureAwait(false);

    /// <summary>获取群发发送结果</summary>
    public async Task<GetGroupmsgSendResultResponse> GetGroupmsgSendResultAsync(GetGroupMsgSendResultRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetGroupmsgSendResultResponse>("/cgi-bin/externalcontact/get_groupmsg_send_result", request, ct).ConfigureAwait(false);

    #endregion

    #region 入群欢迎语素材

    /// <summary>添加入群欢迎语素材</summary>
    public async Task<AddWelcomeTemplateResponse> AddWelcomeTemplateAsync(AddWelcomeTemplateRequest request, CancellationToken ct = default)
        => await _http.PostAsync<AddWelcomeTemplateResponse>("/cgi-bin/externalcontact/group_welcome_template/add", request, ct).ConfigureAwait(false);

    /// <summary>编辑入群欢迎语素材</summary>
    public async Task EditWelcomeTemplateAsync(EditWelcomeTemplateRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/externalcontact/group_welcome_template/edit", request, ct).ConfigureAwait(false);

    /// <summary>获取入群欢迎语素材</summary>
    public async Task<GetWelcomeTemplateResponse> GetWelcomeTemplateAsync(GetWelcomeTemplateRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetWelcomeTemplateResponse>("/cgi-bin/externalcontact/group_welcome_template/get", request, ct).ConfigureAwait(false);

    /// <summary>删除入群欢迎语素材</summary>
    public async Task DelWelcomeTemplateAsync(DelWelcomeTemplateRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/externalcontact/group_welcome_template/del", request, ct).ConfigureAwait(false);

    #endregion

    #region 朋友圈规则组

    /// <summary>获取朋友圈规则组列表</summary>
    public async Task<GetMomentRuleListResponse> GetMomentRuleListAsync(GetMomentRuleListRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetMomentRuleListResponse>("/cgi-bin/externalcontact/get_moment_rule_list", request, ct).ConfigureAwait(false);

    #endregion

    #region 群聊数据统计

    /// <summary>获取群聊数据统计</summary>
    public async Task<GetGroupChatStatisticResponse> GetGroupChatStatisticAsync(GetGroupChatStatisticRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetGroupChatStatisticResponse>("/cgi-bin/externalcontact/groupchat/statistic", request, ct).ConfigureAwait(false);

    #endregion
}

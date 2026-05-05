using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>客户联系服务实现</summary>
public class ExternalContactService
{
    private readonly WecomHttpClient _http;

    public ExternalContactService(WecomHttpClient http) => _http = http;

    /// <summary>获取配置了客户联系功能的成员列表</summary>
    public async Task<string[]> GetFollowUserListAsync(CancellationToken ct = default)
    {
        var resp = await _http.GetAsync<GetFollowUserListResponse>("/cgi-bin/externalcontact/get_follow_user_list", ct: ct);
        return resp.FollowUserList ?? [];
    }

    /// <summary>获取客户列表</summary>
    public async Task<string[]> GetExternalContactListAsync(string userId, CancellationToken ct = default)
    {
        var resp = await _http.GetAsync<GetExternalContactListResponse>("/cgi-bin/externalcontact/list",
            new() { ["userid"] = userId }, ct);
        return resp.ExternalUserIdList ?? [];
    }

    /// <summary>获取客户详情</summary>
    public async Task<GetExternalContactResponse> GetExternalContactAsync(string externalUserId, string? cursor = null, CancellationToken ct = default)
    {
        var query = new Dictionary<string, string?> { ["external_userid"] = externalUserId };
        if (!string.IsNullOrEmpty(cursor)) query["cursor"] = cursor;
        return await _http.GetAsync<GetExternalContactResponse>("/cgi-bin/externalcontact/get", query, ct);
    }

    /// <summary>批量获取客户详情</summary>
    public async Task<BatchGetExternalContactResponse> BatchGetExternalContactAsync(BatchGetByUserRequest request, CancellationToken ct = default)
        => await _http.PostAsync<BatchGetExternalContactResponse>("/cgi-bin/externalcontact/batch/get_by_user", request, ct);

    /// <summary>修改客户备注信息</summary>
    public async Task UpdateRemarkAsync(UpdateRemarkRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/externalcontact/remark", request, ct);

    /// <summary>获取客户群列表</summary>
    public async Task<GetGroupChatListResponse> GetGroupChatListAsync(GetGroupChatListRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetGroupChatListResponse>("/cgi-bin/externalcontact/groupchat/list", request, ct);

    /// <summary>获取「联系客户统计」数据</summary>
    public async Task<GetUserBehaviorDataResponse> GetUserBehaviorDataAsync(GetUserBehaviorDataRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetUserBehaviorDataResponse>("/cgi-bin/externalcontact/get_user_behavior_data", request, ct);

    /// <summary>发送新客户欢迎语</summary>
    public async Task SendWelcomeMsgAsync(SendWelcomeMsgRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/externalcontact/send_welcome_msg", request, ct);

    /// <summary>转换 tmp_external_userid 为 external_userid</summary>
    public async Task<ConvertTmpExternalUserIdResponse> ConvertTmpExternalUserIdAsync(ConvertTmpExternalUserIdRequest request, CancellationToken ct = default)
        => await _http.PostAsync<ConvertTmpExternalUserIdResponse>("/cgi-bin/idconvert/convert_tmp_external_userid", request, ct);

    /// <summary>获取企业标签库</summary>
    public async Task<GetCorpTagListResponse> GetCorpTagListAsync(GetCorpTagListRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetCorpTagListResponse>("/cgi-bin/externalcontact/get_corp_tag_list", request, ct);

    /// <summary>添加企业客户标签</summary>
    public async Task<AddCorpTagResponse> AddCorpTagAsync(AddCorpTagRequest request, CancellationToken ct = default)
        => await _http.PostAsync<AddCorpTagResponse>("/cgi-bin/externalcontact/add_corp_tag", request, ct);

    /// <summary>编辑企业客户标签</summary>
    public async Task<WecomBaseResponse> UpdateCorpTagAsync(UpdateCorpTagRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/externalcontact/edit_corp_tag", request, ct);

    /// <summary>删除企业客户标签</summary>
    public async Task<WecomBaseResponse> DeleteCorpTagAsync(DeleteCorpTagRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/externalcontact/del_corp_tag", request, ct);

    /// <summary>分配在职成员的客户给其他成员</summary>
    public async Task<TransferCustomerResponse> TransferCustomerAsync(TransferCustomerRequest request, CancellationToken ct = default)
        => await _http.PostAsync<TransferCustomerResponse>("/cgi-bin/externalcontact/transfer_customer", request, ct);

    /// <summary>查询客户接替状态（在职）</summary>
    public async Task<GetTransferCustomerResultResponse> GetTransferCustomerResultAsync(GetTransferCustomerResultRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetTransferCustomerResultResponse>("/cgi-bin/externalcontact/transfer_result", request, ct);

    /// <summary>分配在职成员的客户群给其他成员</summary>
    public async Task<TransferGroupChatResponse> TransferGroupChatAsync(TransferGroupChatRequest request, CancellationToken ct = default)
        => await _http.PostAsync<TransferGroupChatResponse>("/cgi-bin/externalcontact/groupchat/onjob_transfer", request, ct);

    /// <summary>查询客户群接替状态</summary>
    public async Task<GetTransferGroupChatResultResponse> GetTransferGroupChatResultAsync(GetTransferGroupChatResultRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetTransferGroupChatResultResponse>("/cgi-bin/externalcontact/groupchat/transfer_result", request, ct);

    /// <summary>分配离职成员的客户给其他成员</summary>
    public async Task<DemotionTransferCustomerResponse> DemotionTransferCustomerAsync(DemotionTransferCustomerRequest request, CancellationToken ct = default)
        => await _http.PostAsync<DemotionTransferCustomerResponse>("/cgi-bin/externalcontact/resigned/transfer_customer", request, ct);

    /// <summary>查询离职客户接替状态</summary>
    public async Task<GetDemotionTransferResultResponse> GetDemotionTransferResultAsync(GetDemotionTransferResultRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetDemotionTransferResultResponse>("/cgi-bin/externalcontact/resigned/transfer_result", request, ct);

    /// <summary>将客户群的 opengid 转换为 chat_id</summary>
    public async Task<GetGroupChatByExternalUserIdResponse> GetGroupChatByExternalUserIdAsync(GetGroupChatByExternalUserIdRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetGroupChatByExternalUserIdResponse>("/cgi-bin/externalcontact/opengid_to_chatid", request, ct);
}
